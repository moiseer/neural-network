using System;

namespace NeuralNetwork.Core.ActivationFunctions
{
    public class HyperbolicTangentFunction : IActivationFunction
    {
        private readonly double alpha;

        public HyperbolicTangentFunction(double alpha = 1)
        {
            this.alpha = alpha;
        }

        public double Compute(double x)
        {
            return Math.Tanh(alpha * x);
        }

        public double ComputeDerivative(double x)
        {
            double y = Compute(x);
            return ComputeDerivative2(y);
        }

        public double ComputeDerivative2(double y)
        {
            return alpha * (1 - y * y);
        }
    }
}
