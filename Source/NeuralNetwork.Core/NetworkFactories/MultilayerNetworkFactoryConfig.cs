using System;
using NeuralNetwork.Core.Functions;
using NeuralNetwork.Core.LearningStrategies;
using NeuralNetwork.Core.Models;

namespace NeuralNetwork.Core.NetworkFactories
{
    public class MultilayerNetworkFactoryConfig
    {
        public IFunction ActivationFunction { get; set; }
        public int HiddenLayerCount { get; set; }
        public int HiddenNeuronCount { get; set; }
        public int InputNeuronCount { get; set; }
        public ILearningStrategy<IMultilayerNeuralNetwork> LearningStrategy { get; set; }
        public int OutputNeuronCount { get; set; }
    }
}
