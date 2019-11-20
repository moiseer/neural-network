using System;
using System.Collections.Generic;
using NeuralNetwork.Core.Data;
using NeuralNetwork.Core.Models;

namespace NeuralNetwork.Core.LearningStrategies
{
    public interface ILearningStrategy<T>
        where T : INeuralNetwork
    {
        /// <summary>
        /// Train neural network
        /// </summary>
        /// <param name="network">Neural network for training</param>
        /// <param name="data">Set of input vectors</param>
        void Train(T network, IList<DataItem> data);
    }
}
