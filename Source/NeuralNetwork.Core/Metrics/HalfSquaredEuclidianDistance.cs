using System;
using NeuralNetwork.Core.LearningStrategies;

namespace NeuralNetwork.Core.Metrics
{
    public class HalfSquaredEuclideanDistance : IMetrics<double>
    {
        public double Calculate(double[] v1, double[] v2)
        {
            double d = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                d += (v1[i] - v2[i]) * (v1[i] - v2[i]);
            }
            return 0.5 * d;
        }

        public double CalculatePartialDerivativeByV2Index(double[] v1, double[] v2, int v2Index)
        {
            return v2[v2Index] - v1[v2Index];
        }
    }
}
