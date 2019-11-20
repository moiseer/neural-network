using System;

namespace NeuralNetwork.Core.Models.Networks
{
    public interface INeuralNetwork
    {
        double[] Output { get; }
        double[] Compute(double[] input);

        void Randomize();
    }
}
