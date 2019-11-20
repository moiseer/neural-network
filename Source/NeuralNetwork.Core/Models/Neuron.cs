using System.Collections.Generic;
using NeuralNetwork.Core.Functions;

namespace NeuralNetwork.Core.Models
{
    public class Neuron : INeuron
    {
        public Neuron(IFunction activationFunction)
        {
            ActivationFunction = activationFunction;
        }

        public IFunction ActivationFunction { get; }
        public double Bias { get; set; }
        public double dEdz { get; set; }
        public double LastNet { get; set; }
        public double LastState { get; set; }
        public double[] Weights { get; set; }
        
        public double Activate(double[] inputVector)
        {
            var net = Net(inputVector);
            var result = ActivationFunction.Compute(net);

            LastState = result;
            return result;
        }

        public double Net(double[] inputVector)
        {
            double result = Bias;
            for(int i = 0; i < inputVector.Length; i++)
            {
                result += inputVector[i] * Weights[i];
            }

            LastNet = result;
            return result;
        }
    }
}
