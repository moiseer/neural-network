using System;

namespace NeuralNetwork.Core.Models
{
    public interface IMultilayerNeuralNetwork : INeuralNetwork
    {
        /// <summary>
        /// Get array of layers of network
        /// </summary>
        ILayer[] Layers { get; }
    }
}
