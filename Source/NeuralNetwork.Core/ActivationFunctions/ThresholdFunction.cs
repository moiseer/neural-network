namespace NeuralNetwork.Core.ActivationFunctions
{
    public class ThresholdFunction : IActivationFunction
    {
        public double Compute(double x)
        {
            return x >= 0 ? 1 : 0;
        }

        public double ComputeDerivative(double x)
        {
            return 0;
        }

        public double ComputeDerivative2(double y)
        {
            return 0;
        }
    }
}
