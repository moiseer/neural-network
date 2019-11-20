using System;

namespace NeuralNetwork.Core.ActivationFunctions
{
    public interface IActivationFunction
    {
        double Compute(double x);
        double ComputeDerivative(double x);
        double ComputeDerivative2(double y);
    }
}
