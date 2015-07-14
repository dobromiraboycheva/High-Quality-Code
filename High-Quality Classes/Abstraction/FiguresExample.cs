using System;

namespace Abstraction
{
    class FiguresExample
    {
        static void Main()
        {
            IFigure circle = new Circle(5.3);
            Console.WriteLine(circle);
            Console.WriteLine();

            IFigure rectangle = new Rectangle(6.2, 5.5);
            Console.WriteLine(rectangle);
        }
    }
}
