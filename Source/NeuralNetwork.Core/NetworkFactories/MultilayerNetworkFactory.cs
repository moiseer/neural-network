using System;
using System.Collections.Generic;
using NeuralNetwork.Core.Functions;
using NeuralNetwork.Core.LearningStrategies;
using NeuralNetwork.Core.Metrics;
using NeuralNetwork.Core.Models;

namespace NeuralNetwork.Core.NetworkFactories
{
    public class MultilayerNetworkFactory
    {
        private readonly MultilayerNetworkFactoryConfig config;
        
        public MultilayerNetworkFactory(MultilayerNetworkFactoryConfig config)
        {
            this.config = config;
        }
        
        public MultilayerNeuralNetwork CreateNetwork()
        {
            var layers = new List<ILayer>();

            // Входной слой.
            var inputNeurons = new List<INeuron>();
            for (int i = 0; i < config.InputNeuronCount; i++)
            {
                inputNeurons.Add(new Neuron(config.ActivationFunction));
            }
            ILayer inputLayer = new InputLayer(inputNeurons.ToArray());
            layers.Add(inputLayer);

            // Скрытые слои.
            for (int i = 0; i < config.HiddenLayerCount; i++)
            {
                var hiddenNeurons = new List<INeuron>();
                for (int j = 0; j < config.HiddenNeuronCount; j++)
                {
                    hiddenNeurons.Add(new Neuron(config.ActivationFunction));
                }

                ILayer hiddenLayer = new Layer(hiddenNeurons.ToArray());
                layers.Add(hiddenLayer);
            }

            // Выходной слой.
            var outputNeurons = new List<INeuron>();
            for (int i = 0; i < config.OutputNeuronCount; i++)
            {
                outputNeurons.Add(new Neuron(config.ActivationFunction));
            }

            ILayer outputLayer = new Layer(outputNeurons.ToArray());
            layers.Add(outputLayer);

            var network = new MultilayerNeuralNetwork(layers.ToArray(), config.LearningStrategy);

            return network;
        }

        public static MultilayerNeuralNetwork CreateDefaultNetwork()
        {
            var learningStrategyConfig = new LearningStrategyConfig
            {
                BatchSize = 10,
                ErrorFunction = new HalfSquaredEuclideanDistance(),
                LearningRate = 1,
                MaxEpoches = 1000000,
                MinError = 0.03,
                MinErrorChange = 0.0000001,
                RegularizationFactor = 0
            };
            var learningStrategy = new BackPropagationFcnLearningStrategy(learningStrategyConfig);
            
            var networkFactoryConfig = new MultilayerNetworkFactoryConfig
            {
                ActivationFunction = new SigmoidFunction(),
                HiddenLayerCount = 1,
                HiddenNeuronCount = 5 * 7,
                InputNeuronCount = 5 * 7,
                OutputNeuronCount = 4,
                LearningStrategy = learningStrategy
            };
            var networkFactory = new MultilayerNetworkFactory(networkFactoryConfig);

            var network = networkFactory.CreateNetwork();
            
            return network;
        }
    }
}
