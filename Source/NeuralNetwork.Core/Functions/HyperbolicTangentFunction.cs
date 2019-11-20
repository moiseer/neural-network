using System;

namespace NeuralNetwork.Core.Functions
{
    public class HyperbolicTangentFunction : IFunction
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

        public double ComputeFirstDerivative(double x)
        {
            double tanh = Compute(x);
            return alpha * (1 - tanh * tanh);
        }
    }
}
