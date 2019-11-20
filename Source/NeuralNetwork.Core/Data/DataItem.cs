using System;

namespace NeuralNetwork.Core.Data
{
    public class DataItem
    {
        public DataItem(double[][] input, double[][] output)
        {
            Input = input;
            Output = output;
        }

        public double[][] Input { get; }

        public double[][] Output { get; }
    }
}
