using System;
using NeuralNetwork.Core.ActivationFunctions;
using NeuralNetwork.Core.Models.Layers;

namespace NeuralNetwork.Core.Models.Networks
{
    public class MultilayerNeuralNetwork : IMultilayerNeuralNetwork
    {
        public MultilayerNeuralNetwork(ILayer[] layers)
        {
            Layers = layers;
        }

        public ILayer[] Layers { get; }

        public double[] Output { get; private set; }

        public static MultilayerNeuralNetwork CreateNetwork(int[] neuronCount, int inputCount, IActivationFunction function)
        {
            for (var i = 0; i < neuronCount.Length; i++)
            {
                if (neuronCount[i]< 1)
                {
                    throw new ArgumentException($"neuronCount[{i}] < 1");
                }
            }

            var layers = new ILayer[neuronCount.Length];
            for (var i = 0; i < layers.Length; i++)
            {
                layers[i] = Layer.CreateLayer(
                    neuronCount[i],
                    (i == 0) ? inputCount : neuronCount[i - 1],
                    function);
            }
            
            var network = new MultilayerNeuralNetwork(layers);

            return network;
        }
        
        public double[] Compute(double[] input)
        {
            Output = input;
            foreach (ILayer layer in Layers)
            {
                Output = layer.Compute(Output);
            }

            return Output;
        }

        public void Randomize()
        {
            foreach (ILayer layer in Layers)
            {
                layer.Randomize();
            }
        }
    }
}
