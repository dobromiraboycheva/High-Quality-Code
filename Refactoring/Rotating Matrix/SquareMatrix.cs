namespace Rotating_Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class SquareMatrix
    {
        private const int MinMatrixSize = 1;
        private const int MaxMatrixSize = 100;
        private int size;
        private int[,] matrix;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < SquareMatrix.MinMatrixSize || SquareMatrix.MaxMatrixSize < value)
                {
                    throw new ArgumentException("Matrix size must be between " + SquareMatrix.MinMatrixSize + " and " + SquareMatrix.MaxMatrixSize);
                }

                this.size = value;
            }
        }

        public int[,] Matrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public void RotatingFill()
        {
            Coordinates position = this.matrix.GetStartingPosition();
            Direction direction = Direction.DownRight;
            int cellValue = 1;
            int rowChange = RotatingUtils.GetRowChange(direction);
            int colChange = RotatingUtils.GetColChange(direction);

            while (cellValue <= Math.Pow(this.Size, 2))
            {
                this.matrix[position.Row, position.Col] = cellValue;

                if (!this.matrix.CanGoToDirection(position.Row + rowChange, position.Col + colChange))
                {
                    bool neighboursAreFilled = false;

                    if (this.matrix.NeighboursAreFilled(position.Row, position.Col))
                    {
                        neighboursAreFilled = true;
                        position = this.matrix.GetStartingPosition();

                        if (position == null)
                        {
                            break;
                        }

                        direction = Direction.DownRight;
                    }
                    else
                    {
                        direction = this.matrix.GetNextDirection(direction, position.Row, position.Col);
                    }

                    rowChange = RotatingUtils.GetRowChange(direction);
                    colChange = RotatingUtils.GetColChange(direction);

                    if (neighboursAreFilled)
                    {
                        continue;
                    }
                }

                position.Row += rowChange;
                position.Col += colChange;
                cellValue++;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0,-5}", this.matrix[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
