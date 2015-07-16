namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class ArraySearchingAlgorithems
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is with null value.");
            Debug.Assert(value != null, "Search value is null.");
            Debug.Assert(startIndex <= endIndex, "Start index is greater than end index.");
            Debug.Assert(ArrayProperties.IsSorted(arr), "Array is not sorted.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the left half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            Debug.Assert(!ArrayProperties.HasValue(arr, value), "The array has the searchead value and incorrect returns -1.");
            return -1;
        }
    }
}