using System;
using NeuralNetwork.Core.Functions;

namespace NeuralNetwork.Core.Models
{
    public interface INeuron
    {
        IFunction ActivationFunction { get; }

        /// <summary>
        /// Offset/bias of neuron (default is 0).
        /// Смещение.
        /// </summary>
        double Bias { get; set; }

        double dEdz { get; set; }

        /// <summary>
        /// Last calculated NET in NET
        /// </summary>
        double LastNet { get; set; }

        /// <summary>
        /// Last calculated state in Activate
        /// </summary>
        double LastState { get; set; }

        /// <summary>
        /// Weights of the neuron.
        /// Веса входящих связей (от нейронов предыдущего слоя к данному).
        /// </summary>
        double[] Weights { get; set; }

        /// <summary>
        /// Compute state of neuron
        /// </summary>
        /// <param name="inputVector">Input vector (must be the same dimension as was set in SetDimension)</param>
        /// <returns>State of neuron</returns>
        double Activate(double[] inputVector);

        /// <summary>
        /// Compute NET of the neuron by input vector
        /// </summary>
        /// <param name="inputVector">Input vector (must be the same dimension as was set in SetDimension)</param>
        /// <returns>NET of neuron</returns>
        double Net(double[] inputVector);
    }
}
