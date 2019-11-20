using System;

namespace NeuralNetwork.Core.Models
{
    public interface ILayer
    {
        /// <summary>
        /// Get input dimension of neurons
        /// </summary>
        int InputDimension { get; }

        /// <summary>
        /// Get last output of the layer
        /// </summary>
        double[] LastOutput { get; }

        /// <summary>
        /// Get neurons of the layer
        /// </summary>
        INeuron[] Neurons { get;}

        /// <summary>
        /// Compute output of the layer
        /// </summary>
        /// <param name="inputVector">Input vector</param>
        /// <returns>Output vector</returns>
        double[] Compute(double[] inputVector);
    }
}
