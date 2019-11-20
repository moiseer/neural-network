using System;

namespace NeuralNetwork.Core.ActivationFunctions
{
    public class SigmoidFunction : IActivationFunction
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

        public double ComputeDerivative(double x)
        {
            double y = Compute(x);
            return ComputeDerivative2(y);
        }

        public double ComputeDerivative2(double y)
        {
            return alpha * y * ( 1 - y );
        }
    }
}
