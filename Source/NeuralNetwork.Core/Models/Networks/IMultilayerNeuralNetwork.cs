using System;
using NeuralNetwork.Core.Models.Layers;

namespace NeuralNetwork.Core.Models.Networks
{
    public interface IMultilayerNeuralNetwork : INeuralNetwork
    {
        ILayer[] Layers { get; }
    }
}
