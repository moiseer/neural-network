using System;
using System.Collections.Generic;

namespace NeuralNetwork.Core.Data
{
    public class DataItemFactory
    {
        public static List<DataItem> GetNumericData()
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
                0, 0, 0, 1
            };
            var one = new DataItem(oneInputData, oneOutputData);
            
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
                0, 0, 1, 0
            };
            var two = new DataItem(twoInputData, twoOutputData);
            
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
                0, 0, 1, 1
            };
            var three = new DataItem(threeInputData, threeOutputData);
            
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
                0,1,0,0
            };
            var four = new DataItem(fourInputData, fourOutputData);

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
                0, 1, 0, 1
            };
            var five = new DataItem(fiveInputData, fiveOutputData);
            
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
                0, 1, 1, 0
            };
            var six = new DataItem(sixInputData, sixOutputData);
            
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
                0, 1, 1, 1
            };
            var seven = new DataItem(sevenInputData, sevenOutputData);
            
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
                1, 0, 0, 0
            };
            var eight = new DataItem(eightInputData, eightOutputData);
            
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
                1, 0, 0, 1
            };
            var nine = new DataItem(nineInputData, nineOutputData);
            
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
                0, 0, 0, 0
            };
            var zero = new DataItem(zeroInputData, zeroOutputData);

            var data = new List<DataItem>
            {
                zero, one, two, three, four,
                five, six, seven, eight, nine
            };

            return data;
        }
    }
}
