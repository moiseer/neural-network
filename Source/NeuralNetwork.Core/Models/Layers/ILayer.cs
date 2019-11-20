using System;
using NeuralNetwork.Core.Models.Neurons;

namespace NeuralNetwork.Core.Models.Layers
{
    public interface ILayer
    {
        INeuron[] Neurons { get; }
        double[] Output { get; }
        double[] Compute(double[] input);
        void Randomize();
    }
}
