using System.Linq;
using NeuralNetwork.Core.ActivationFunctions;
using NeuralNetwork.Core.Models.Layers;
using NeuralNetwork.Core.Models.Networks;
using NeuralNetwork.Core.Models.Neurons;

namespace NeuralNetwork.Core.LearningStrategies
{
    public class BackPropagationLearning : ISupervisedLearning
    {
	    private readonly IMultilayerNeuralNetwork network;
        private readonly double[][] neuronErrors;
        private readonly double[][][] weightsUpdates;
        private readonly double[][] thresholdsUpdates;

        /// <summary>
        /// Learning rate
        /// </summary>
        /// <remarks>Значение определяет скорость обучения. Значение по умолчанию равно 0,1.</remarks>
        public double LearningRate { get; set; } = 0.1;

        /// <summary>
        /// Momentum
        /// </summary>
        /// <remarks>Значение определяет часть обновления предыдущего веса, используемую на текущей итерации.
        /// Значения обновления веса рассчитываются на каждой итерации в зависимости от ошибки нейрона.
        /// Импульс указывает количество обновлений, которое нужно использовать с предыдущей итерации,
        /// и количество обновлений, которое нужно использовать с текущей итерации. Если значение равно,
        /// например, 0,1, то для обновления значения веса используется 0,1 часть предыдущего обновления
        /// и 0,9 часть текущего обновления. Значение по умолчанию равно 0.0.</remarks>
        public double Momentum { get; set; } = 0;

        public BackPropagationLearning(IMultilayerNeuralNetwork network)
        {
            this.network = network;

            // создание ошибкок и массивов дельт
            neuronErrors = new double[network.Layers.Length][];
            weightsUpdates = new double[network.Layers.Length][][];
            thresholdsUpdates = new double[network.Layers.Length][];

            // инициализировать ошибки и массивы дельт для каждого слоя
            for (int i = 0; i < network.Layers.Length; i++)
            {
                ILayer layer = network.Layers[i];

                neuronErrors[i] = new double[layer.Neurons.Length];
                weightsUpdates[i] = new double[layer.Neurons.Length][];
                thresholdsUpdates[i] = new double[layer.Neurons.Length];

                for (int j = 0; j < layer.Neurons.Length; j++)
                {
                    weightsUpdates[i][j] = new double[layer.Neurons[j].Weights.Length];
                }
            }
        }

        public double Run(double[] input, double[] output)
        {
            network.Compute(input);
            double error = CalculateError(network, output);
            CalculateUpdates(network, input);
            UpdateNetwork(network);
            
            return error;
        }

        public double RunEpoch(double[][] input, double[][] output)
        {
            double error = 0;

            for (int i = 0, n = input.Length; i < n; i++)
            {
                error += Run(input[i], output[i]);
            }

            return error;
        }
        
        // HalfSquared Euclidean Distance
        private double CalculateError(IMultilayerNeuralNetwork network, double[] expectedOutput)
        {
	        double error = 0;
	        int layersCount = network.Layers.Length;

	        IActivationFunction function = network.Layers[0].Neurons[0].ActivationFunction;

	        ILayer layer = network.Layers.Last();
	        double[] errors = neuronErrors.Last();

	        for (int i = 0, n = layer.Neurons.Length; i < n; i++)
	        {
		        double output = layer.Neurons[i].Output;
		        double e = expectedOutput[i] - output;
		        errors[i] = e * function.ComputeDerivative2(output);
		        error += (e * e);
	        }

	        for (int j = layersCount - 2; j >= 0; j--)
	        {
		        layer = network.Layers[j];
		        ILayer layerNext = network.Layers[j + 1];
		        errors = neuronErrors[j];
		        double[] errorsNext = neuronErrors[j + 1];

		        for (int i = 0, n = layer.Neurons.Length; i < n; i++)
		        {
			        var sum = 0.0;
			        for (int k = 0; k < layerNext.Neurons.Length; k++)
			        {
				        sum += errorsNext[k] * layerNext.Neurons[k].Weights[i];
			        }

			        errors[i] = sum * function.ComputeDerivative2(layer.Neurons[i].Output);
		        }
	        }

	        return error / 2.0;
        }

        private void CalculateUpdates(IMultilayerNeuralNetwork network, double[] input)
        {
	        INeuron neuron;
	        double[] neuronWeightUpdates;
	        double error;

	        ILayer layer = network.Layers[0];
	        double[] errors = neuronErrors[0];
	        double[][] layerWeightsUpdates = weightsUpdates[0];
	        double[] layerThresholdUpdates = thresholdsUpdates[0];

	        for (int i = 0; i < layer.Neurons.Length; i++)
	        {
		        neuron = layer.Neurons[i];
		        error = errors[i];
		        neuronWeightUpdates = layerWeightsUpdates[i];

		        for (int j = 0; j < neuron.Weights.Length; j++)
		        {
			        neuronWeightUpdates[j] = LearningRate * (
				        Momentum * neuronWeightUpdates[j] +
				        (1.0 - Momentum) * error * input[j]
			        );
		        }

		        layerThresholdUpdates[i] = LearningRate * (
			        Momentum * layerThresholdUpdates[i] +
			        (1.0 - Momentum) * error
		        );
	        }

	        for (int k = 1; k < network.Layers.Length; k++)
	        {
		        ILayer layerPrev = network.Layers[k - 1];
		        layer = network.Layers[k];
		        errors = neuronErrors[k];
		        layerWeightsUpdates = weightsUpdates[k];
		        layerThresholdUpdates = thresholdsUpdates[k];

		        for (int i = 0; i < layer.Neurons.Length; i++)
		        {
			        neuron = layer.Neurons[i];
			        error = errors[i];
			        neuronWeightUpdates = layerWeightsUpdates[i];

			        for (int j = 0; j < neuron.Weights.Length; j++)
			        {
				        neuronWeightUpdates[j] = LearningRate * (
					        Momentum * neuronWeightUpdates[j] +
					        (1.0 - Momentum) * error * layerPrev.Neurons[j].Output
				        );
			        }

			        layerThresholdUpdates[i] = LearningRate * (
				        Momentum * layerThresholdUpdates[i] +
				        (1.0 - Momentum) * error
			        );
		        }
	        }
        }

        private void UpdateNetwork(IMultilayerNeuralNetwork network)
        {
	        for (int i = 0; i < network.Layers.Length; i++)
	        {
		        ILayer layer = network.Layers[i];
		        double[][] layerWeightsUpdates = weightsUpdates[i];
		        double[] layerThresholdUpdates = thresholdsUpdates[i];

		        for (int j = 0; j < layer.Neurons.Length; j++)
		        {
			        INeuron neuron = layer.Neurons[j];
			        double[] neuronWeightUpdates = layerWeightsUpdates[j];

			        for (int k = 0, s = neuron.Weights.Length; k < s; k++)
			        {
				        neuron.Weights[k] += neuronWeightUpdates[k];
			        }

			        neuron.Threshold += layerThresholdUpdates[j];
		        }
	        }
        }
    }
}
