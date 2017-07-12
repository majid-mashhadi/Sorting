using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg
{
    public class Sorting
    {
        #region Insertion Sort
        public static void InsertSort(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = input.Length - 1; j > i; j--)
                {
                    if (input[i] > input[j])
                    {
                        swap(input, i, j);
                    }
                }
            }
        }
        #endregion

        #region Selection Sort
        public static void SelectionSort(int[] input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int swapIndex = i;
                for (int j = 0; j < i; j++)
                {
                    if (input[j] > input[swapIndex])
                    {
                        swapIndex = j;
                    }
                }
                if (swapIndex != i)
                {
                    swap(input, i, swapIndex);
                }

            }
        }
        #endregion


        #region Bubble Sort
        public static void BubbleSort(int[] input)
        {
            bool sorted = false;
            for (int i = 0; i < input.Length; i++)
            {
                sorted = true;
                for (int j = 0; j < input.Length - 1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        swap(input, j, j + 1);
                        sorted = false;
                    }
                }
                if (sorted)
                    break;
            }
        }

        #endregion

        #region QuickSort
        public static void QuickSort(int[] input)
        {
            QuickSortRecursive(input, 0, input.Length - 1);
        }

        private static void QuickSortRecursive(int[] input, int left, int right)
        {
            while (left < right)
            {
                int p = MidPartition(input, left, right);
                QuickSortRecursive(input, left, p - 1);
                left = p + 1;
            }
        }

        private static void QuickSort(int[] input, int left, int right)
        {

            if (left >= right) return;
            int p = MidPartition(input, left, right);
            QuickSort(input, left, p);
            QuickSort(input, p + 1, right);
        }

        private static int MidPartition(int[] input, int left, int right)
        {
            int pivot = (left + right) / 2;
            while (left <= pivot && right >= pivot)
            {
                while (left <= pivot && input[left] < input[pivot]) { left++; }
                while (right >= pivot && input[right] > input[pivot]) { right--; };
                if (left < right)
                {
                    swap(input, left, right);
                }
                left++;
                right--;
            }
            return pivot;
        }

        private static void swap(int[] input, int left, int right)
        {
            int temp = input[left];
            input[left] = input[right];
            input[right] = temp;
        }

        private static int lastPartition(int[] input, int left, int right)
        {
            for (int i = left; i < right; i++)
            {
                if (input[i] > input[right])
                {
                    swap(input, i, right);
                }
            }
            return right - 1;
        }
        #endregion

        #region Merge Sort
        public static void MergeSort(int[] input)
        {
            int[] temp = new int[input.Length];
            MergeSort(input, temp, 0, input.Length - 1);
        }
        private static void MergeSort(int[] input, int[] temp, int left, int right)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            MergeSort(input, temp, left, mid);
            MergeSort(input, temp, mid + 1, right);
            MergeHalves(input, temp, left, mid, right);
        }

        private static void MergeHalves(int[] input, int[] temp, int left, int mid, int right)
        {
            int leftIndex = left;
            int rightIndex = mid + 1;
            int index = left;
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (input[leftIndex] < input[rightIndex])
                {
                    temp[index++] = input[leftIndex++];
                }
                else
                {
                    temp[index++] = input[rightIndex++];
                }
            }

            Array.Copy(input, leftIndex, temp, index, mid - leftIndex + 1);
            Array.Copy(input, rightIndex, temp, index, right - rightIndex + 1);
            Array.Copy(temp, left, input, left, right - left + 1);
        }

        #endregion

       
    }
}
