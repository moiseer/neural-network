using System;
using System.Collections.Generic;

namespace NeuralNetwork.Core.Models
{
    public class Layer : ILayer
    {
        public Layer(INeuron[] neurons)
        {
            Neurons = neurons;
        }

        public int InputDimension { get; private set; }
        public double[] LastOutput { get; private set; }
        public INeuron[] Neurons { get; }

        public double[] Compute(double[] inputVector)
        {
            InputDimension = inputVector.Length;

            var result = new List<double>();
            foreach (INeuron neuron in Neurons)
            {
                result.Add(neuron.Activate(inputVector));
            }

            LastOutput = result.ToArray();
            return result.ToArray();
        }
    }
}
