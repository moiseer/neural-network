using System;
using NeuralNetwork.Core.ActivationFunctions;
using NeuralNetwork.Core.Models.Neurons;

namespace NeuralNetwork.Core.Models.Layers
{
    public class Layer : ILayer
    {
        public Layer(INeuron[] neurons)
        {
            Neurons = neurons;
            Output = new double[neurons.Length];
        }

        public INeuron[] Neurons { get; }
        public double[] Output { get; private set; }

        public static Layer CreateLayer(int neuronCount, int inputCount, IActivationFunction function)
        {
            if (inputCount < 1)
            {
                throw new ArgumentException("inputCount < 1");
            }

            if (neuronCount < 1)
            {
                throw new ArgumentException("neuronCount < 1");
            }

            var neurons = new INeuron[neuronCount];
            for (var i = 0; i < neurons.Length; i++)
            {
                neurons[i] = new Neuron(inputCount, function);
            }

            var layer = new Layer(neurons);

            return layer;
        }
        
        public double[] Compute(double[] input)
        {
            for (var i = 0; i < Neurons.Length; i++)
            {
                Output[i] = Neurons[i].Compute(input);
            }

            return Output;
        }

        public void Randomize()
        {
            foreach (INeuron neuron in Neurons)
            {
                neuron.Randomize();
            }
        }
    }
}
