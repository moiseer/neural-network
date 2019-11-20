using System;

namespace NeuralNetwork.Core.Data
{
    public class DataItem
    {
        public DataItem()
        {
        }

        public DataItem(double[] input, double[] output)
        {
            Input = input;
            Output = output;
        }

        public double[] Input { get; set; }

        public double[] Output { get; set; }
    }
}
