using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bbit_1_uzd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = InitializeArray(20, 20);
            PrintArray(array);
            PrintMinMaxValues(array);
            PrintArrayAscendingOrder(array);
        }

        static int[,] InitializeArray(int rowSize, int columnSize)
        {
            int[,] array = new int[rowSize, columnSize];
            Random random = new Random();

            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    array[i, j] = random.Next(0, 100);
                }
            }

            return array;
        }

        static void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            Console.Write("    ");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{j,4}");
            }
            Console.WriteLine();

            Console.Write("    ");
            for (int j = 0; j < cols; j++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{i,2} | ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j],4}");
                }
                Console.WriteLine();
            }
        }


        static void PrintMinMaxValues(int[,] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Array is empty or null.");
                return;
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            List<(int, int)> minCoords = new List<(int, int)>();
            List<(int, int)> maxCoords = new List<(int, int)>();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minCoords.Clear();
                        minCoords.Add((i, j));
                    }
                    else if (array[i, j] == min)
                    {
                        minCoords.Add((i, j));
                    }

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxCoords.Clear();
                        maxCoords.Add((i, j));
                    }
                    else if (array[i, j] == max)
                    {
                        maxCoords.Add((i, j));
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Mazākais cipars: {min}");
            Console.WriteLine($"Lielākais cipars: {max}");
            Console.WriteLine();

            Console.WriteLine("Maksimālās koordinātes:");
            foreach (var (row, column) in maxCoords)
            {
                Console.WriteLine($"{row}.rinda {column}.kolona");
            }
            Console.WriteLine();

            Console.WriteLine("Minimālās koordinātes:");
            foreach (var (row, column) in minCoords)
            {
                Console.WriteLine($"{row}.rinda {column}.kolona");
            }
        }


        static void PrintArrayAscendingOrder(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[] tempArray = new int[rows * cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tempArray[index++] = array[i, j];
                }
            }

            Array.Sort(tempArray);

            int[,] sortedArray = new int[rows, cols];
            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sortedArray[i, j] = tempArray[index++];
                }
            }

            PrintArray(sortedArray);
        }
    }
}
