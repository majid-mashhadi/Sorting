using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickSort;
namespace SortingAlgorithms
{
    class MergeSortArray
    {
        static int[] temp = null;
        public static void Main()
        {
            int[] input = new int[] { 7, 6, 8, 77, 12, 3, 1, 20, 17 };
            temp = new int[input.Length];

            displayArray(input, "Initial Array:");

            mergeSort(input);
            displayArray(input, "Sorted Array:");

            Console.ReadKey();
        }

        private static void mergeSort(int[] input)
        {
            mergeSort(input, 0, input.Length - 1);
        }
        private static void mergeSort(int[] input, int left, int right)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            mergeSort(input, left, mid);
            mergeSort(input, mid + 1, right);
            mergeHalves(input, left, mid, right);
        }

        private static void mergeHalves(int[] input, int left, int mid, int right)
        {
            int leftIndex = left;
            int rightIndex = mid + 1;
            int tempIndex = leftIndex;
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (input[leftIndex] <= input[rightIndex])
                    temp[tempIndex++] = input[leftIndex++];
                else
                    temp[tempIndex++] = input[rightIndex++];
            }
            Array.Copy(input, leftIndex, temp, tempIndex, mid - leftIndex + 1);
            Array.Copy(input, rightIndex, temp, tempIndex, right - rightIndex + 1);
            Array.Copy(temp, left, input, left, right - left + 1);
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
