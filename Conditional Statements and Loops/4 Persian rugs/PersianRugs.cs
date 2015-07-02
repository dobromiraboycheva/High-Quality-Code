using System;

class PersianRugs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int hight = 2 * n + 1;
        int width = 2 * n + 1;
        char[,] matrix = new char[hight, width];
        char space = ' ';
        char dot = '.';
        char ex = 'X';
        char slash = '/';
        char backslash = '\\';
        char hashtag = '#';

        for (int row = 0; row < hight; row++)
        {
            for (int col = 0; col < width; col++)
            {
                matrix[row, col] = dot;
            }
        }

        for (int row = 0; row < hight; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == n && col == n)
                {
                    matrix[row, col] = ex;
                }

                if (row > 0 && row < hight - 1 && (col < row) && col < width - row - 1)
                {
                    matrix[row, col] = hashtag;
                    matrix[row, width - 1 - col] = hashtag;
                }

                if (row >= 0 && row <= hight - 1 && (col == row) && row != n && col != n)
                {
                    matrix[row, col] = backslash;
                    matrix[row, width - 1 - col] = slash;
                }

                if (row >= 0 && row < n && col == row + d + 1 && col < n)
                {
                    matrix[row, col] = backslash;
                    matrix[row, width - 1 - col] = slash;
                    matrix[hight - 1 - row, col] = slash;
                    matrix[hight - 1 - row, width - 1 - col] = backslash;
                }

                if (row >= 0 && row < n && (col > row && col <= row + d) && col <= n)
                {
                    matrix[row, col] = space;
                    matrix[row, width - 1 - col] = space;
                    matrix[hight - 1 - row, col] = space;
                    matrix[hight - 1 - row, width - 1 - col] = space;
                }

                if (row == n - d - 1 && col == n)
                {
                    matrix[row, col] = space;
                    matrix[hight - 1 - row, col] = space;
                }

            }
        }

        for (int row = 0; row < hight; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
