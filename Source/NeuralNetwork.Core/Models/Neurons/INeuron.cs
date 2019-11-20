using System;
using NeuralNetwork.Core.ActivationFunctions;

namespace NeuralNetwork.Core.Models.Neurons
{
    public interface INeuron
    {
        IActivationFunction ActivationFunction { get; }
        double Output { get; }

        // IActivationNeuron
        double Threshold { get; set; }
        double[] Weights { get; set; }
        double Compute(double[] input);
        void Randomize();
    }
}
