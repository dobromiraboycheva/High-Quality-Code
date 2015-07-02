using System;

class TreeNumbers
{
    static void Main()
    {
        long firstNumber = long.Parse(Console.ReadLine());
        long secondNumber = long.Parse(Console.ReadLine());
        long thirdNumber = long.Parse(Console.ReadLine());
       
        long maxValue = Math.Max(Math.Max(firstNumber, secondNumber), thirdNumber);
        long minValue = Math.Min(Math.Min(firstNumber, secondNumber), thirdNumber);
        double avarageSum = (Convert.ToDouble(firstNumber) + Convert.ToDouble(secondNumber) + Convert.ToDouble(thirdNumber)) / 3;
        
        Console.WriteLine(maxValue);
        Console.WriteLine(minValue);
        Console.WriteLine("{0:F2}", avarageSum);
    }
}
