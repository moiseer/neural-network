using System;

namespace NeuralNetwork.Core.ActivationFunctions
{
    public class BipolarSigmoidFunction : IActivationFunction
    {
        private readonly double alpha;

        public BipolarSigmoidFunction(double alpha = 1)
        {
            this.alpha = alpha;
        }
        
        public double Compute(double x)
        {
            return 2 / (1 + Math.Exp(-alpha * x)) - 1;
        }

        public double ComputeDerivative(double x)
        {
            double y = Compute(x);
            return ComputeDerivative2(y);
        }

        public double ComputeDerivative2(double y)
        {
            return alpha * (1 - y * y) / 2;
        }
    }
}
