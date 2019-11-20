using System;

namespace NeuralNetwork.Core.LearningStrategies
{
    public interface IMetrics<T>
    {
        double Calculate(T[] v1, T[] v2);

        /// <summary>
        /// Calculate value of partial derivative by v2[v2Index]
        /// </summary>
        T CalculatePartialDerivativeByV2Index(T[] v1, T[] v2, int v2Index);
    }
}
