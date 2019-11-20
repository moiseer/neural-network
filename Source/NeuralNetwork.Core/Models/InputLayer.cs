using System;
using System.Collections.Generic;

namespace NeuralNetwork.Core.Models
{
    public class InputLayer : ILayer
    {
        public InputLayer(INeuron[] neurons)
        {
            Neurons = neurons;
        }

        public int InputDimension { get; private set; }
        public double[] LastOutput { get; private set; }
        public INeuron[] Neurons { get; }
        public double[] Compute(double[] inputVector)
        {
            if (Neurons.Length != inputVector.Length)
            {
                throw new ArgumentException("Количество входных нейронов и входных данных не совпадает.");
            }
            InputDimension = inputVector.Length;
            
            var result = new List<double>();
            for (var i = 0; i < inputVector.Length; i++)
            {
                result.Add(Neurons[i].Activate(new []{inputVector[i]}));
            }

            
            LastOutput = result.ToArray();
            return result.ToArray();
        }
    }
}
