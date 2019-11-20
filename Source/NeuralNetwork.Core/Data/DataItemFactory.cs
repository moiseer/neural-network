using System;
using System.Collections.Generic;

namespace NeuralNetwork.Core.Data
{
    public class DataItemFactory
    {
        public static DataItem GetNumericData()
        {
            var oneInputData = new double[]
            {
                0, 0, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                1, 1, 1, 1, 1
            };
            var oneOutputData = new double[]
            {
                0, 1, 0, 0, 0, 0, 0, 0, 0, 0
            };
            
            var twoInputData = new double[]
            {
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 1, 0,
                0, 1, 1, 0, 0,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 1
            };
            var twoOutputData = new double[]
            {
                0, 0, 1, 0, 0, 0, 0, 0, 0, 0
            };
            
            var threeInputData = new double[]
            {
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                0, 0, 1, 1, 0,
                0, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            };
            var threeOutputData = new double[]
            {
                0, 0, 0, 1, 0, 0, 0, 0, 0, 0
            };
            
            var fourInputData = new double[]
            {
                0, 0, 1, 1, 0,
                0, 1, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 0, 0, 1, 0,
                1, 1, 1, 1, 1,
                0, 0, 0, 1, 0,
                0, 0, 0, 1, 0
            };
            var fourOutputData = new double[]
            {
                0, 0, 0, 0, 1, 0, 0, 0, 0, 0
            };

            var fiveInputData = new double[]
            {
                1, 1, 1, 1, 1,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 0,
                0, 0, 0, 0, 1,
                0, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            };
            var fiveOutputData = new double[]
            {
                0, 0, 0, 0, 0, 1, 0, 0, 0, 0
            };
            
            var sixInputData = new double[]
            {
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 0,
                1, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            };
            var sixOutputData = new double[]
            {
                0, 0, 0, 0, 0, 0, 1, 0, 0, 0
            };
            
            var sevenInputData = new double[]
            {
                1, 1, 1, 1, 1,
                0, 0, 0, 0, 1,
                0, 0, 0, 1, 0,
                0, 0, 1, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 0, 0, 0
            };
            var sevenOutputData = new double[]
            {
                0, 0, 0, 0, 0, 0, 0, 1, 0, 0
            };
            
            var eightInputData = new double[]
            {
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            };
            var eightOutputData = new double[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 1, 0
            };
            
            var nineInputData = new double[]
            {
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 1,
                0, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            };
            var nineOutputData = new double[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 1
            };
            
            var zeroInputData = new double[]
            {
                0, 1, 1, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 1, 1, 0
            };
            var zeroOutputData = new double[]
            {
                1, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };



            double[][] input = new[]
            {
                zeroInputData, oneInputData, twoInputData, threeInputData, fourInputData,
                fiveInputData, sixInputData, sevenInputData, eightInputData, nineInputData
            };

            double[][] output = new[]
            {
                zeroOutputData, oneOutputData, twoOutputData, threeOutputData, fourOutputData,
                fiveOutputData, sixOutputData, sevenOutputData, eightOutputData, nineOutputData
            };
            
            var data=new DataItem(input, output);
            
            return data;
        }
    }
}
