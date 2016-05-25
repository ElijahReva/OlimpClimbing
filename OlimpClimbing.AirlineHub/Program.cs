using System;
using System.Collections.Generic;

namespace OlimpClimbing.AirlineHub
{
    public class Program
    {
        //matrix with distance
        //row summ
        private static void Main()
        {
            //var first = Coord.Parse(Console.ReadLine());
            //var second = Coord.Parse(Console.ReadLine());
            var p = new Pilot();
            var coors = new List<Coord>
            {
                
                new Coord(3.20f, -15.00f),
                new Coord(20.1f, -175f),
                new Coord(-30.2f, 10f)

            };
            var count = coors.Count;
            float[,] matrix = new float[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] = p.DistanceHaversine(coors[i], coors[j]);
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            DebugMatrix(matrix);
            var min = FindMin(matrix);
            Console.WriteLine(min);
            Console.WriteLine(coors[min]);
            Console.ReadLine();
        }

        private static int FindMin(float[,] matrix)
        {
            int result = -1;
            float min = float.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                float summ = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    summ += matrix[i, j];
                }

                if (!(summ < min)) continue;
                min = summ;
                result = i;
            }
            return result;
        }

        private static void DebugMatrix(float[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
