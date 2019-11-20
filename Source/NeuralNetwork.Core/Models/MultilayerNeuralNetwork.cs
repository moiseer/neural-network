using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Core.Data;
using NeuralNetwork.Core.LearningStrategies;

namespace NeuralNetwork.Core.Models
{
    public class MultilayerNeuralNetwork : IMultilayerNeuralNetwork
    {
        private readonly ILearningStrategy<IMultilayerNeuralNetwork> learningStrategy;

        public MultilayerNeuralNetwork(ILayer[] layers, ILearningStrategy<IMultilayerNeuralNetwork> learningStrategy)
        {
            Layers = layers;
            this.learningStrategy = learningStrategy;
            Random rnd = new Random();

            foreach (INeuron neuron in Layers[0].Neurons)
            {
                neuron.Weights = new double[]{rnd.NextDouble()};
            }
            for (int i = 1; i < Layers.Length; i++)
            {
                foreach (INeuron neuron in Layers[i].Neurons)
                {
                    neuron.Weights = new double[Layers[i-1].Neurons.Length];
                    for (var j = 0; j < neuron.Weights.Length; j++)
                    {
                        neuron.Weights[j] = 1;
                    }
                }
            }
        }

        public ILayer[] Layers { get; }

        public double[] ComputeOutput(double[] inputVector)
        {
            double[] lastOutput = inputVector;
            foreach (ILayer layer in Layers)
            {
                var result = layer.Compute(lastOutput);
                lastOutput = result;
            }

            return lastOutput;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Train(IList<DataItem> data)
        {
            learningStrategy.Train(this, data);
        }
    }
}
