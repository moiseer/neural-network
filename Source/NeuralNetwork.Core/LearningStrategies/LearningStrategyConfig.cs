using System;

namespace NeuralNetwork.Core.LearningStrategies
{
    public class LearningStrategyConfig
    {
        /// <summary>
        /// Size of the butch. -1 means fullbutch size.
        /// </summary>
        public int BatchSize { get; set; }

        /// <summary>
        /// Function to minimize
        /// </summary>
        public IMetrics<double> ErrorFunction { get; set; }

        public double LearningRate { get; set; }

        public int MaxEpoches { get; set; }

        /// <summary>
        /// If cumulative error for all training examples is less then MinError, then algorithm stops
        /// </summary>
        public double MinError { get; set; }

        /// <summary>
        /// If cumulative error change for all training examples is less then MinErrorChange, then algorithm stops
        /// </summary>
        public double MinErrorChange { get; set; }

        public double RegularizationFactor { get; set; }
    }
}
