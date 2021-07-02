// ------------------------------------------------------------------------------------------------
//  <copyright file="Threat.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace AnonymousThreat
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Threat
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();

            while (true)
            {
                var comand = Console.ReadLine().Split().ToArray();

                if (comand[0] == "3:1")
                {
                    Console.Write(string.Join(" ", input));
                    break;
                }

                if (comand[0] == "merge")
                {
                    var startIndex = int.Parse(comand[1]);
                    var endIndex = int.Parse(comand[2]);
                    Merge(input, startIndex, endIndex);
                }
                else if (comand[0] == "divide")
                {
                    var index = int.Parse(comand[1]);
                    var partitions = int.Parse(comand[2]);
                    Divide(input, index, partitions);
                }
            }
        }

        private static void Merge(List<string> input, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > input.Count - 1)
            {
                endIndex = input.Count - 1;
            }

            for (var j = startIndex + 1; j <= endIndex; j++)
            {
                input[startIndex] += input[startIndex + 1];
                input.RemoveAt(startIndex + 1);
            }
        }

        private static void Divide(List<string> input, int index, int partitions)
        {
            var partitionData = input[index];
            input.RemoveAt(index);
            var partSize = partitionData.Length / partitions;
            var reminder = partitionData.Length % partitions;

            var tmpData = new List<string>();

            for (var i = 0; i < partitions; i++)
            {
                string tmpString = null;

                for (var p = 0; p < partSize; p++)
                {
                    tmpString += partitionData[(i * partSize) + p];
                }

                if (i == partitions - 1 && reminder != 0)
                {
                    tmpString += partitionData.Substring(partitionData.Length - reminder);
                }

                tmpData.Add(tmpString);
            }

            input.InsertRange(index, tmpData);
        }
    }
}