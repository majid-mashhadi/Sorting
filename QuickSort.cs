using System;
using System.Linq;

namespace SortAlgorithms
{
    class QuickSortAlgorithm
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 7, 6, 8, 77, 12, 3, 1, 20, 17 };
            displayArray(input, "Initial Array:");

            QuickSort(input);
            displayArray(input, "Sorted Array:");

            Console.ReadKey();
        }

        private static void QuickSort(int[] inputArray)
        {
            if (inputArray != null)
            {
                QuickSort(inputArray, 0, inputArray.Count() - 1);
            }
        }

        private static void QuickSort(int[] inputArray, int low, int high)
        {
            if (low < high)
            {
                int pivot = partition(inputArray, low, high);
                QuickSort(inputArray, low, pivot - 1);
                QuickSort(inputArray, pivot, high);
            }
        }

        private static int partition(int[] inputArray, int left, int right)
        {
            int pivot = inputArray[(left + right) / 2];
            while (left <= right)
            {
                while (inputArray[left] < pivot) left++;
                while (inputArray[right] > pivot) right--;
                if (left <= right)
                {
                    swap(inputArray, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private static void swap(int[] inputArray, int first, int second)
        {
            int temp = inputArray[first];
            inputArray[first] = inputArray[second];
            inputArray[second] = temp;
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
