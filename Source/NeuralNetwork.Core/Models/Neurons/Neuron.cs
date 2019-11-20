using System;
using NeuralNetwork.Core.ActivationFunctions;

namespace NeuralNetwork.Core.Models.Neurons
{
    // ActivationNeuron
    public class Neuron : INeuron
    {
        private readonly Random random;

        public Neuron(int inputCount, IActivationFunction activationFunction)
        {
            if (inputCount < 1)
            {
                throw new ArgumentException("inputCount < 1");
            }
            
            random = new Random();
            ActivationFunction = activationFunction;
            Weights = new double[inputCount];
        }

        public IActivationFunction ActivationFunction { get; }
        public double Output { get; private set; }
        public double Threshold { get; set; }
        public double[] Weights { get; set; }

        public double Compute(double[] input)
        {
            if (input.Length != Weights.Length)
            {
                throw new ArgumentException("input.Length != Weights.Length");
            }

            double sum = 0.0;
            for (int i = 0; i < Weights.Length; i++)
            {
                sum += Weights[i] * input[i];
            }

            sum += Threshold;
            Output = ActivationFunction.Compute(sum);

            return Output;
        }

        public void Randomize()
        {
            for (var i = 0; i < Weights.Length; i++)
            {
                Weights[i] = random.NextDouble();
            }

            Threshold = random.NextDouble();
        }
    }
}
