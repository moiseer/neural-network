using System;

namespace NeuralNetwork.Core.Functions
{
    public interface IFunction
    {
        double Compute(double x);
        double ComputeFirstDerivative(double x);
    }
}
