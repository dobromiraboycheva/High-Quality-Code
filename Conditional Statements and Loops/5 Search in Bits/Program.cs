using System;

class SearchInBits
{
    static void Main()
    {
        const int NumberOfColoms = 30;

        int surching4Bits = int.Parse(Console.ReadLine());
        int numberOfRows = int.Parse(Console.ReadLine());
        int surching4BitsCounter = 0;
        int[,] matrix = new int[numberOfRows, NumberOfColoms];

        for (int row = 0; row < numberOfRows; row++)
        {
            int currentRow = int.Parse(Console.ReadLine());

            for (int col = 0; col < NumberOfColoms; col++)
            {
                matrix[row, NumberOfColoms - 1 - col] = (currentRow >> col) & 1;
            }
        }

        string surching4BitsBinarry = Convert.ToString(surching4Bits, 2).PadLeft(4, '0');
        string current4BitsBinarry = "";

        for (int row = 0; row < numberOfRows; row++)
        {
            current4BitsBinarry = "";
            for (int col = 0; col < NumberOfColoms - 3; col++)
            {
                current4BitsBinarry = Convert.ToString(matrix[row, col]) + Convert.ToString(matrix[row, col + 1]) + Convert.ToString(matrix[row, col + 2]) + Convert.ToString(matrix[row, col + 3]);
                
                if (current4BitsBinarry == surching4BitsBinarry)
                {
                    surching4BitsCounter++;
                }
            }
        }
       
        Console.WriteLine(surching4BitsCounter);
    }
}
