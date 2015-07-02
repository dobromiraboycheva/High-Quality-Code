using System;
using System.Collections.Generic;
using System.Numerics;

class ConsoleApplication1
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        List<BigInteger> numbers = new List<BigInteger>();
        
        while (inputLine != "END")
        {
            numbers.Add(BigInteger.Parse(inputLine));
            inputLine = Console.ReadLine();
        }



        if (numbers.Count < 10)
        {
            BigInteger product = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    product = ProductOfOddNumbers(numbers, product, i);
                }
            }
            Console.WriteLine(product);
        }
        else
        {
            BigInteger productFirst10Elements = 1;
            BigInteger productAfter10Element = 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < 10)
                {
                    productFirst10Elements = ProductOfOddNumbers(numbers, productFirst10Elements, i);
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        productAfter10Element = ProductOfOddNumbers(numbers, productAfter10Element, i);
                    }
                }
            }
            Console.WriteLine(productFirst10Elements);
            Console.WriteLine(productAfter10Element);
        }

    }

    private static BigInteger ProductOfOddNumbers(List<BigInteger> numbers, BigInteger product, int i)
    {
        if (i % 2 != 0)
        {
            BigInteger currentProductFromDigits = 1;
            while (numbers[i] > 0)
            {
                byte currentDigit = (byte)(numbers[i] % 10);

                if (currentDigit != 0)
                {
                    currentProductFromDigits *= currentDigit;

                }
                numbers[i] /= 10;
            }
            product *= currentProductFromDigits;
        }
        return product;
    }
}
