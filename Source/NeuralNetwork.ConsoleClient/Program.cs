using System;
using System.Collections.Generic;
using NeuralNetwork.Core.Data;
using NeuralNetwork.Core.NetworkFactories;
using Serilog;

namespace NeuralNetwork.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            
            
            Console.WriteLine("Создание нейронной сети...");

            var network = MultilayerNetworkFactory.CreateDefaultNetwork();
            
            Console.WriteLine("Создание нейронной сети завершено.");

            List<DataItem> data = DataItemFactory.GetNumericData();

            network.Train(data);

            for (int i = 0; i < data.Count; i++)
            {
                double[] outputs = network.ComputeOutput(data[i].Input);
                string strIn = "";
                foreach (var input in data[i].Output)
                    strIn += $"{input},";
                string strOut = "";
                foreach (var output in outputs)
                    strOut += $"{output: 0.00},";
                
                Console.WriteLine($"{i}. Expected {strIn}, Actual {strOut}");
            }
        }
    }
}
