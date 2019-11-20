using System;
using System.Linq;
using NeuralNetwork.Core.ActivationFunctions;
using NeuralNetwork.Core.Data;
using NeuralNetwork.Core.LearningStrategies;
using NeuralNetwork.Core.Models.Networks;

namespace NeuralNetwork.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Создание нейронной сети...");

            DataItem data = DataItemFactory.GetNumericData();

            int inputCount = data.Input.First().Length;
            var neuronCount = new[] { 10 };
            IActivationFunction function = new BipolarSigmoidFunction();
            double learningRate = 0.1;
            double momentum = 0;

            int maxEpochNumber = 1000000;
            double minErrorChange = 0.000001;
            double minError = 0.001;
            
            var network = MultilayerNeuralNetwork.CreateNetwork(neuronCount, inputCount, function);
            network.Randomize();
            
            Console.WriteLine("Создание нейронной сети завершено.");

            var teacher = new PerceptronLearning(network)
            {
                LearningRate = learningRate
            };
            
            int epochNumber = 1;
            double lastError = double.MaxValue;
            double error;
            double errorChange;
            Console.WriteLine("Start learning...");

            do
            {
                DateTime dtStart = DateTime.Now;
                error = teacher.RunEpoch( data.Input, data.Output ) / data.Input.Length;
                Console.WriteLine(
                    $"Epoch #{epochNumber} finished; " +
                    $"current error is {error}; " +
                    $"it takes: {(DateTime.Now - dtStart).Duration()}");

                errorChange = Math.Abs(lastError - error);
                lastError = error;
                epochNumber++;
            }
            while (epochNumber < maxEpochNumber &&
                error > minError &&
                errorChange > minErrorChange);

            for (int i = 0; i < data.Input.Length; i++)
            {
                double[] outputs = network.Compute(data.Input[i]);
                string strIn = "";
                foreach (var input in data.Output[i])
                    strIn += $"{input},";
                string strOut = "";
                foreach (var output in outputs)
                    strOut += $"{Math.Abs(output):0.00},";
                
                Console.WriteLine($"{i}. Expected {strIn} Actual {strOut}");
            }
        }
    }
}
