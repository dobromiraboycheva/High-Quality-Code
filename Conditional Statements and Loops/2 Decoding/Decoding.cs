using System;
using System.Collections.Generic;

class Decoding
{
    static void Main()
    {
        const int AsciiFirstDigit = 48;
        const int AsciiLastDigit = 57;
        const int AsciiFirstLetterUppercase = 65;
        const int AsciiLastLetterUppercase = 90;
        const int AsciiFirstLetterLowercase = 97;
        const int AsciiLastLetterLowercase = 122;

        byte SALT = byte.Parse(Console.ReadLine());
        string inputLine = Console.ReadLine();

        List<double> cod = new List<double>();
        List<char> chars = new List<char>();

        for (int i = 0; i < inputLine.Length; i++)
        {
            if (inputLine[i] == '@')
            {
                break;
            }

            chars.Add(inputLine[i]);
        }

        for (int i = 0; i < chars.Count; i++)
        {
            if ((int)chars[i] >= AsciiFirstDigit && (int)chars[i] <= AsciiLastDigit)
            {
                cod.Add((int)chars[i] + SALT + 500);
            }
            else if (((int)chars[i] >= AsciiFirstLetterUppercase && (int)chars[i] <= AsciiLastLetterUppercase) || ((int)chars[i] >= AsciiFirstLetterLowercase && (int)chars[i] <= AsciiLastLetterLowercase))
            {
                cod.Add((int)chars[i] * SALT + 1000);
            }
            else
            {
                cod.Add((int)chars[i] - SALT);

                if (cod[i] < 0)
                {
                    cod[i] *= -1;
                }
            }
        }

        for (int i = 0; i < cod.Count; i++)
        {
            if (i % 2 == 0)
            {
                cod[i] /= 100;
                Console.WriteLine("{0:0.00}", cod[i]);
            }
            else
            {
                cod[i] *= 100;
                Console.WriteLine("{0}", cod[i]);
            }
        }

    }
}