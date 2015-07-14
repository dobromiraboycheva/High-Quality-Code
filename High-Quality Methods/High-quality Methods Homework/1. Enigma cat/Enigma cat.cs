using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class EnigmaCat
{
    const int POW_TO_NUMBER = 17;

    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        BigInteger[] decimalNumber = abcToDecimal(input);
        string[] result = DecimalToABC(decimalNumber);
        Console.WriteLine(String.Join(" ", result));



    }

    private static string[] DecimalToABC(BigInteger[] decimalNumber)
    {
        string[] result = new string[decimalNumber.Length];

        for (int i = 0; i < decimalNumber.Length; i++)
        {
            string currentSymbols = string.Empty;
            string currentRev = string.Empty;

            do
            {
                BigInteger digit = decimalNumber[i] % 26;
                currentSymbols += ConvertDecimal(digit);
                decimalNumber[i] /= 26;

            } while (decimalNumber[i] > 0);

            for (int j = currentSymbols.Length - 1; j >= 0; j--)
            {
                currentRev += currentSymbols[j];
            }

            result[i] = currentRev;
        }

        return result;
    }

    private static BigInteger[] abcToDecimal(string[] input)
    {
        BigInteger[] decimalNumber = new BigInteger[input.Length];

        for (int j = 0; j < input.Length; j++)
        {         
            BigInteger curentNumber = 0;
            string currentSymbol = input[j];

            for (int i = 0; i < currentSymbol.Length; i++)
            {
                BigInteger currentDigit = ConvertABCToDecimal(currentSymbol[i]);

                curentNumber += currentDigit * PowNumber(currentSymbol.Length - i - 1);
            }

            decimalNumber[j] = curentNumber;
        }
        return decimalNumber;
    }

    private static BigInteger ConvertABCToDecimal(char symbol)
    {
        switch (symbol)
        {
            case 'a': return 0;
            case 'b': return 1;
            case 'c': return 2;
            case 'd': return 3;
            case 'e': return 4;
            case 'f': return 5;
            case 'g': return 6;
            case 'h': return 7;
            case 'i': return 8;
            case 'j': return 9;
            case 'k': return 10;
            case 'l': return 11;
            case 'm': return 12;
            case 'n': return 13;
            case 'o': return 14;
            case 'p': return 15;
            case 'q': return 16;
            case 'r': return 17;
            case 's': return 18;
            case 't': return 19;
            case 'u': return 20;
            default: throw new ArgumentException();
        }
    }

    private static char ConvertDecimal(BigInteger number)
    {
        switch ((int)number)
        {
            case 0: return 'a';
            case 1: return 'b';
            case 2: return 'c';
            case 3: return 'd';
            case 4: return 'e';
            case 5: return 'f';
            case 6: return 'g';
            case 7: return 'h';
            case 8: return 'i';
            case 9: return 'j';
            case 10: return 'k';
            case 11: return 'l';
            case 12: return 'm';
            case 13: return 'n';
            case 14: return 'o';
            case 15: return 'p';
            case 16: return 'q';
            case 17: return 'r';
            case 18: return 's';
            case 19: return 't';
            case 20: return 'u';
            case 21: return 'v';
            case 22: return 'w';
            case 23: return 'x';
            case 24: return 'y';
            case 25: return 'z';

            default: throw new ArgumentException();
        }
    }

    static BigInteger PowNumber(int power)
    {
        BigInteger result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= POW_TO_NUMBER;
        }
        return result;
    }
}
