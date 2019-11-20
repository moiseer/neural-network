using System;
using NeuralNetwork.Core.Models.Layers;
using NeuralNetwork.Core.Models.Networks;
using NeuralNetwork.Core.Models.Neurons;

namespace NeuralNetwork.Core.LearningStrategies
{
    public class PerceptronLearning : ISupervisedLearning
    {
        private readonly IMultilayerNeuralNetwork network;

        public PerceptronLearning(IMultilayerNeuralNetwork network)
        {
            if (network.Layers.Length != 1)
            {
                throw new ArgumentException("Invalid nuaral network. It should have one layer only.");
            }

            this.network = network;
        }

        /// <summary>
        /// Learning rate
        /// </summary>
        /// <remarks>Значение определяет скорость обучения. Значение по умолчанию равно 0,1.</remarks>
        public double LearningRate { get; set; } = 0.1;

        public double Run(double[] input, double[] output)
        {
            double[] networkOutput = network.Compute(input);

            ILayer layer = network.Layers[0];

            double error = 0.0;

            for (int j = 0; j < layer.Neurons.Length; j++)
            {
                double e = output[j] - networkOutput[j];

                if (Math.Abs(e) > 0.000001)
                {
                    INeuron perceptron = layer.Neurons[j];

                    for (int i = 0; i < perceptron.Weights.Length; i++)
                    {
                        perceptron.Weights[i] += LearningRate * e * input[i];
                    }

                    perceptron.Threshold += LearningRate * e;

                    error += Math.Abs(e);
                }
            }

            return error;
        }

        public double RunEpoch(double[][] input, double[][] output)
        {
            double error = 0.0;

            for (int i = 0, n = input.Length; i < n; i++)
            {
                error += Run(input[i], output[i]);
            }

            return error;
        }
    }
}
