namespace Abstraction
{
    using System;
    using System.Text;

    public class Rectangle : Figure, IFigure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Width cannot be less than or equal to 0.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Height cannot be less than or equal to 0.");
                }

                this.height = value;
            }
        }


        public override double GetPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double GetSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine()
                .AppendFormat("Width: {0}; Height: {1}", this.Width, this.Height);

            return result.ToString();
        }
    }
}
