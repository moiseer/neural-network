using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Core.Data;
using NeuralNetwork.Core.Models;
using Serilog;

namespace NeuralNetwork.Core.LearningStrategies
{
    public class BackPropagationFcnLearningStrategy : ILearningStrategy<IMultilayerNeuralNetwork>
    {
        private readonly LearningStrategyConfig config;
        private readonly ILogger logger = Log.ForContext<BackPropagationFcnLearningStrategy>();
        private readonly Random random;

        public BackPropagationFcnLearningStrategy(LearningStrategyConfig config)
        {
            this.config = config;
            random = new Random();
        }

        public void Train(IMultilayerNeuralNetwork network, IList<DataItem> data)
        {
            if (config.BatchSize < 1 || config.BatchSize > data.Count)
            {
                config.BatchSize = data.Count;
            }

            double currentError = float.MaxValue;
            double lastError;
            int epochNumber = 0;
            
            logger.Information("Start learning...");

            do
            {
                lastError = currentError;
                DateTime dtStart = DateTime.Now;

                //preparation for epoch
                var trainingIndices = new int[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    trainingIndices[i] = i;
                }

                if (config.BatchSize > 0)
                {
                    trainingIndices = Shuffle(trainingIndices);
                }

                //process data set
                int currentIndex = 0;
                do
                {
                    //accumulated error for batch, for weights and biases
                    var nablaWeights = new double[network.Layers.Length][][];
                    var nablaBiases = new double[network.Layers.Length][];
                    
                    
                    for (int i = 0; i < network.Layers.Length; i++)
                    {
                        nablaBiases[i] = new double[network.Layers[i].Neurons.Length];
                        nablaWeights[i] = new double[network.Layers[i].Neurons.Length][];
                        for (int j = 0; j < network.Layers[i].Neurons.Length; j++)
                        {
                            nablaBiases[i][j] = 0;
                            nablaWeights[i][j] = new double[network.Layers[i].Neurons[j].Weights.Length];
                            for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                            {
                                nablaWeights[i][j][k] = 0;
                            }
                        }
                    }
                    

                    //process one batch
                    for (int inBatchIndex = currentIndex; inBatchIndex < currentIndex + config.BatchSize && inBatchIndex < data.Count; inBatchIndex++)
                    {
                        //forward pass
                        double[] realOutput = network.ComputeOutput(data[trainingIndices[inBatchIndex]].Input);

                        //backward pass, error propagation
                        //last layer
                        foreach (INeuron neuron in network.Layers.Last().Neurons)
                        {
                            int neuronIndex = Array.IndexOf(network.Layers.Last().Neurons, neuron);
                            
                            neuron.dEdz = config.ErrorFunction.CalculatePartialDerivativeByV2Index(
                                    data[inBatchIndex].Output,
                                    realOutput, 
                                    neuronIndex) *
                                neuron.ActivationFunction.ComputeFirstDerivative(neuron.LastNet);
                            
                            nablaBiases.Last()[neuronIndex] += config.LearningRate * neuron.dEdz;

                            foreach (double weight in neuron.Weights)
                            {
                                int weightIndex = Array.IndexOf(neuron.Weights, weight);
                                
                                nablaWeights.Last()[neuronIndex][weightIndex] += 
                                    config.LearningRate * 
                                    (neuron.dEdz * 
                                        (network.Layers.Length > 1 ? 
                                            network.Layers[^2].Neurons[weightIndex].LastState : 
                                            data[inBatchIndex].Input[weightIndex]) + 
                                        config.RegularizationFactor * weight / data.Count);
                            }
                        }

                        //hidden layers
                        for (int hiddenLayerIndex = network.Layers.Length - 2; hiddenLayerIndex >= 0; hiddenLayerIndex--)
                        {
                            foreach (INeuron neuron in network.Layers[hiddenLayerIndex].Neurons)
                            {
                                int neuronIndex = Array.IndexOf(network.Layers[hiddenLayerIndex].Neurons, neuron);
                            
                                neuron.dEdz = 0;
                                foreach (INeuron neuronNext in network.Layers[hiddenLayerIndex + 1].Neurons)
                                {
                                    neuron.dEdz += neuronNext.Weights[neuronIndex] * neuronNext.dEdz;
                                }
                                
                                neuron.dEdz *= neuron.ActivationFunction.ComputeFirstDerivative(neuron.LastNet);
                                
                                nablaBiases[hiddenLayerIndex][neuronIndex] += config.LearningRate * neuron.dEdz;

                                foreach (double weight in neuron.Weights)
                                {
                                    int weightIndex = Array.IndexOf(neuron.Weights, weight);

                                    nablaWeights[hiddenLayerIndex][neuronIndex][weightIndex] += 
                                        config.LearningRate * 
                                        (neuron.dEdz * 
                                            (hiddenLayerIndex > 0 ? 
                                                network.Layers[hiddenLayerIndex - 1].Neurons[weightIndex].LastState : 
                                                data[inBatchIndex].Input[weightIndex]) + 
                                            config.RegularizationFactor * weight / data.Count);
                                }
                            }
                        }
                    }

                    //update weights and bias
                    foreach (ILayer layer in network.Layers)
                    {
                        int layerIndex = Array.IndexOf(network.Layers, layer);
                        foreach (INeuron neuron in layer.Neurons)
                        {
                            int neuronIndex = Array.IndexOf(layer.Neurons, neuron);
                            neuron.Bias -= nablaBiases[layerIndex][neuronIndex];
                            for (int weightIndex = 0; weightIndex < neuron.Weights.Length; weightIndex++)
                            {
                                neuron.Weights[weightIndex] -= nablaWeights[layerIndex][neuronIndex][weightIndex];
                            }
                        }
                    }

                    currentIndex += config.BatchSize;
                }
                while (currentIndex < data.Count);

                //recalculating error on all data
                //real error
                currentError = 0;
                foreach (DataItem item in data)
                {
                    double[] realOutput = network.ComputeOutput(item.Input);
                    currentError += config.ErrorFunction.Calculate(item.Output, realOutput);
                }

                currentError /= data.Count;
                
                //regularization term
                if (Math.Abs(config.RegularizationFactor - 0d) > double.Epsilon)
                {
                    double reg = 0;
                    foreach (ILayer layer in network.Layers)
                    {
                        foreach (INeuron neuron in layer.Neurons)
                        {
                            foreach (double weight in neuron.Weights)
                            {
                                reg += weight * weight;
                            }
                        }
                    }

                    currentError += config.RegularizationFactor * reg / (2 * data.Count);
                }

                epochNumber++;

                logger.Information(
                    $"Epoch #{epochNumber} finished; " +
                    $"current error is {currentError}; " +
                    $"it takes: {(DateTime.Now - dtStart).Duration()}");
            }
            while (epochNumber < config.MaxEpoches &&
                currentError > config.MinError &&
                Math.Abs(currentError - lastError) > config.MinErrorChange); // протестировать без последнего условия.
        }

        private int[] Shuffle(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (random.NextDouble() >= 0.3)
                {
                    int newIndex = random.Next(arr.Length);
                    int tmp = arr[i];
                    arr[i] = arr[newIndex];
                    arr[newIndex] = tmp;
                }
            }
            return arr;
        }
    }
}
