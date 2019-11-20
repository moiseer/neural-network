using System;
using System.Collections.Generic;
using System.IO;
using NeuralNetwork.Core.Data;

namespace NeuralNetwork.Core.Models
{
    public interface INeuralNetwork
    {
        /// <summary>
        /// Compute output vector by input vector
        /// </summary>
        /// <param name="inputVector">Input vector (double[])</param>
        /// <returns>Output vector (double[])</returns>
        double[] ComputeOutput(double[] inputVector);

        void Save();

        /// <summary>
        /// Train network with given inputs and outputs
        /// </summary>
        /// <param name="data">Set of input vectors</param>
        void Train(IList<DataItem> data);
    }
}
