namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class ArraySortingAlgorithms
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is with null value.");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            Debug.Assert(ArrayProperties.IsSorted(arr), "Array is not sorted.");
        }

        public static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
         where T : IComparable<T>
        {
            int minElementIndex = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        public static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
