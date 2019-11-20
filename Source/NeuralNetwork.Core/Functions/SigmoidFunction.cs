using System;

namespace NeuralNetwork.Core.Functions
{
    public class SigmoidFunction : IFunction
    {
        private readonly double alpha;

        public SigmoidFunction(double alpha = 1)
        {
            this.alpha = alpha;
        }

        public double Compute(double x)
        {
            return 1 / (1 + Math.Exp(-1 * alpha * x));
        }

        public double ComputeFirstDerivative(double x)
        {
            double r = Compute(x);
            return alpha * r * (1 - r);
        }
    }
}
