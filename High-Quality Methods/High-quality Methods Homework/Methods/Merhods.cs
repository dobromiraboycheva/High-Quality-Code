namespace Methods
{
    using System;

    internal class Methods
    {

        /// <summary>
        /// Positioning of SideA line between two points
        /// </summary>
        internal enum Position
        {
            Horizontal,
            Vertical,
            PointsOverlap,
            Other
        }

        /// <summary>
        /// Format string modifier
        /// </summary>
        internal enum PrintingFormat
        {
            Percent,
            Round,
            AlignRight
        }

        internal static double CalcTriangleAreaWithThreeSides(double SideA, double SideB, double SideC)
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                Console.Error.WriteLine("Sides should be positive numbers.");
                return -1;
            }

            double semiPerimeter = (SideA + SideB + SideC) / 2;
            double semiPerimeterMinusEachSide = semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC);
            double area = Math.Sqrt(semiPerimeterMinusEachSide);

            return area;
        }

        internal static string DigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid digit");
            }
        }

        internal static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Must enter least one argument");
            }

            int maxNumber = int.MinValue;

            for (int i = 1; i < elements.Length; i++)
            {
                maxNumber = Math.Max(maxNumber, elements[i]);
            }

            return maxNumber;
        }

        internal static void PrintAsNumber(object number, PrintingFormat format)
        {
            switch (format)
            {
                case PrintingFormat.Percent:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case PrintingFormat.Round:
                    Console.WriteLine("{0:f0}", number);
                    break;
                case PrintingFormat.AlignRight:
                    Console.WriteLine("{0:8}", number);
                    break;
                default:
                    throw new ArithmeticException("Invalid printing format");
            }
        }


        internal static double CalculateDistanceBetweenTwoPoints(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            double substractionProductX = (secondPointX - firstPointX) * (secondPointX - firstPointX);
            double substractionProductY = (secondPointY - firstPointY) * (secondPointY - firstPointY);
            double distance = Math.Sqrt(substractionProductX + substractionProductY);

            return distance;
        }

        internal static Position GetLinePosition(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            if (firstPointY == secondPointY)
            {
                return Position.Horizontal;
            }
            else if (firstPointX == secondPointX)
            {
                return Position.Vertical;
            }
            else if (firstPointX == secondPointX && firstPointY == secondPointY)
            {
                return Position.PointsOverlap;
            }
            else
            {
                return Position.Other;
            }
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleAreaWithThreeSides(3, 4, 5));

            Console.WriteLine(DigitToWord(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, PrintingFormat.Round);
            PrintAsNumber(0.75, PrintingFormat.Percent);
            PrintAsNumber(2.30, PrintingFormat.AlignRight);

            double distance = CalculateDistanceBetweenTwoPoints(3, -1, 3, 2.5);
            Console.WriteLine(distance);
            Position linePosition = GetLinePosition(3, -1, 3, 2.5);
            Console.WriteLine("Line position:"+linePosition);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 3, 11), "Vidin", "gamer, high results");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}