namespace Assertions_Homework
{
    using System;

    internal class AssertionsExaple
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            ArraySortingAlgorithms.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            ArraySortingAlgorithms.SelectionSort(new int[0]); // Test sorting empty array
            ArraySortingAlgorithms.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(ArraySearchingAlgorithems.BinarySearch(arr, -1000));
            Console.WriteLine(ArraySearchingAlgorithems.BinarySearch(arr, 0));
            Console.WriteLine(ArraySearchingAlgorithems.BinarySearch(arr, 17));
            Console.WriteLine(ArraySearchingAlgorithems.BinarySearch(arr, 10));
            Console.WriteLine(ArraySearchingAlgorithems.BinarySearch(arr, 1000));
        }
    }
}