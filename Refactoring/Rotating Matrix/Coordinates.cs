namespace Rotating_Matrix
{
    using System;

    public class Coordinates
    {
        private int row;
        private int col;

        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        { 
            get
            {
                return this.row;
            }
            
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows cannot be negative.");
                }

                this.row = value;
            } 
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows cannot be negative.");
                }

                this.col = value;
            }
        }
    }
}
