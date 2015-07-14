using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Loverof2
{
    static void Main()
    {
        BigInteger sum = 0;
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        long numbersOfMove = long.Parse(Console.ReadLine());
        string[] codeString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        long[] codes = new long[codeString.Length];

        for (int i = 0; i < codeString.Length; i++)
        {
            codes[i] = long.Parse(codeString[i]);
        }

        long coeff = Math.Max(rows, cols);
        long[] row = new long[codes.Length];
        long[] col = new long[codes.Length];

        for (int i = 0; i < codes.Length; i++)
        {
            row[i] = codes[i] / coeff;
            col[i] = codes[i] % coeff;
        }

        BigInteger[,] matrix = InputMatrix(rows, cols);
        bool[,] used = new bool[rows, cols];
        sum = Direction(row, col, matrix, used);
        Console.WriteLine(sum);
    }

    private static BigInteger Direction(long[] row, long[] col, BigInteger[,] matrix, bool[,] used)
    {
        BigInteger result = 0;
        int rowStart = matrix.GetLength(0) - 1;
        int colStart = 0;

        for (int i = 0; i < row.Length; i++)
        {

            if (i > 0)
            {
                rowStart = (int)row[i - 1];
                colStart = (int)col[i - 1];
                if (rowStart >= row[i])
                {
                    //"UP"
                    for (int r = rowStart - 1; r >= row[i]; r--)
                    {
                        if (!used[r, colStart])
                        {
                            result += matrix[r, colStart];
                            used[r, colStart] = true;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    if (colStart <= col[i])
                    {
                        //Up and left
                        for (int c = colStart + 1; c <= col[i]; c++)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (colStart > col[i])
                    {
                        //up and right
                        for (int c = colStart - 1; c >= col[i]; c--)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                            else
                            {
                                continue;
                            }

                        }
                    }
                }
                else if (rowStart < row[i])
                {
                    //down
                    for (int r = rowStart + 1; r <= row[i]; r++)
                    {
                        if (!used[r, colStart])
                        {
                            result += matrix[r, colStart];
                            used[r, colStart] = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (colStart <= col[i])
                    {
                        //down and left
                        for (int c = colStart + 1; c <= col[i]; c++)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (colStart > col[i])
                    {
                        //down and right
                        for (int c = colStart - 1; c >= col[i]; c--)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            else
            {
                if (rowStart >= row[i])
                {
                    //"UP"
                    for (int r = rowStart; r >= row[i]; r--)
                    {
                        if (!used[r, colStart])
                        {
                            result += matrix[r, colStart];
                            used[r, colStart] = true;
                        }
                    }
                    if (colStart < col[i])
                    {
                        //Up and left
                        for (int c = colStart + 1; c <= col[i]; c++)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                        }
                    }
                    else if (colStart > col[i])
                    {
                        //up and right
                        for (int c = colStart; c > col[i]; c--)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                        }
                    }
                }
                else if (rowStart < row[i])
                {
                    //down
                    for (int r = rowStart; r <= row[i]; r++)
                    {
                        if (!used[r, col[i]])
                        {
                            result += matrix[r, col[i]];
                            used[r, col[i]] = true;
                        }
                    }
                    if (colStart < col[i])
                    {
                        //down and left
                        for (int c = colStart + 1; c <= col[i]; c++)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                        }
                    }
                    else if (colStart > col[i])
                    {
                        //down and right
                        for (int c = colStart - 1; c > col[i]; c--)
                        {
                            if (!used[row[i], c])
                            {
                                result += matrix[row[i], c];
                                used[row[i], c] = true;
                            }
                        }
                    }
                }

            }
        }
        return result;
    }


    private static BigInteger[,] InputMatrix(int rows, int cols)
    {
        BigInteger[,] matrix = new BigInteger[rows, cols];
        matrix[rows - 1, 0] = 1;

        for (int row = rows - 1; row >= 0; row--)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = (BigInteger)Math.Pow(2, rows - row - 1 + col);

            }
        }

        return matrix;
    }

}
