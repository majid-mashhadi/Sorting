using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickSort;
namespace SortingAlgorithms
{
    class BubbleSortArray
    {
        public static void Main()
        {
            int[] input = new int[] { 7, 6, 8, 77, 12, 3, 1, 20, 17 };
            displayArray(input, "Initial Array:");

            bubbleSort(input);
            displayArray(input, "Sorted Array:");

            Console.ReadKey();
        }

        private static void bubbleSort(int[] input)
        {
            bubbleSortOptimize(input, 0, input.Length - 1);
        }
 /// <summary>
 /// two versions of bubble sort, 
 /// the first one uses two loops and doesn't care that array is sorted or not, run time is always o(n^2)
 /// the second one checks if array is already sorted or not and dosn't continue if it's already sorted. it has a better run time that the first one.
 /// </summary>
 /// <param name="input"></param>
 /// <param name="left"></param>
 /// <param name="right"></param>
        private static void bubbleSort(int[] input, int left, int right)
        {
            if (input == null || input.Length == 0 || left >= right) return;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (input[i] < input[j])
                    {
                        swap(input, i, j);
                    }
                }
            }
        }

        private static void bubbleSortOptimize(int[] input, int left, int right)
        {
            if (input == null || input.Length == 0 || left >= right) return;
            bool sorted = false;
            int rightColumn = input.Length - 1;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < rightColumn; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        swap(input, i, i + 1);
                        sorted = false;
                    }
                }
                rightColumn--;
            }
        }

        private static void swap(int[] input, int first, int second)
        {
            int temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }

        private static void displayArray(int[] inputArray, string title)
        {
            System.Console.WriteLine(title);
            System.Console.Write(string.Join(" , ", inputArray));
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
