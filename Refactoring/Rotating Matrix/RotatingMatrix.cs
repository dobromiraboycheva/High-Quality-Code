﻿namespace Rotating_Matrix
{
    using System;

    protected class RotatingMatrix
    {
        internal static void Main()
        {
            SquareMatrix matrix = new SquareMatrix(15);
            matrix.RotatingFill();
            Console.WriteLine(matrix);
        }
    }
}
