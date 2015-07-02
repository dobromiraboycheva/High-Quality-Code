using System;
using Task_1_Class_Chef;
public class MainClass
{
    static void Main()
    {
        const int MinX = 5;
        const int MaxX = 15;
        const int MinY = 5;
        const int MaxY = 15;

        Potato potato = new Potato();


        /*
          Potato potato;
            //... 
            if (potato != null)
               if(!potato.HasNotBeenPeeled && !potato.IsRotten)
                Cook(potato);
         */


        if (potato != null)
        {
            bool notPeerled = !potato.IsPeeled;
            bool notRotten = !potato.IsRotten;

            if (notPeerled && notRotten)
            {
                potato.Cook();
            }
        }

        int x = 7;
        int y = 8;

        bool shouldVisitCell = true;

        /*
          if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
                {
                   VisitCell();
                }
         */


        if (shouldVisitCell && IsInRange(x, MinX, MaxX) && IsInRange(y, MinY, MaxY))
        {
            VisitCell();
        }

    }

    public static void VisitCell()
    {
        Console.WriteLine("Visited call");
    }

    public static bool IsInRange(int value, int min, int max)
    {
        bool isInRange = value >= min && value <= max;

        return isInRange;
    }
}