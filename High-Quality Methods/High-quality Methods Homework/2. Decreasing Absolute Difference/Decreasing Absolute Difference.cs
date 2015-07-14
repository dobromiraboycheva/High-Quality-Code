using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class DecreasingAbsoluteDifferences
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger[][] seq = InputArray(n);

        BigInteger[][] absDiff = AbsDifference(seq);
        bool[] result = DecreasingSequence(absDiff);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

    }

    private static bool[] DecreasingSequence(BigInteger[][] absDiff)
    {
        bool[] result = new bool[absDiff.GetLength(0)];
        bool currentResult = true;

        for (int i = 0; i < absDiff.GetLength(0); i++)
        {
            for (int j = 0; j < absDiff[i].Length; j++)
            {
                if (j != 0 && ((absDiff[i][j - 1] - absDiff[i][j]) == 0 || (absDiff[i][j - 1] - absDiff[i][j]) == 1))
                {
                    currentResult = true;
                }
                else
                {
                    currentResult = false;
                    break;
                }
            }

            result[i] = currentResult;
        }

        return result;
    }

    private static BigInteger[][] AbsDifference(BigInteger[][] seq)
    {
        BigInteger[][] absDiff = new BigInteger[seq.GetLength(0)][];

        for (int i = 0; i < seq.GetLength(0); i++)
        {
            absDiff[i] = new BigInteger[seq[i].Length - 1];

            for (int j = 1; j < seq[i].Length; j++)
            {
                absDiff[i][j - 1] = Math.Abs((long)seq[i][j] - (long)seq[i][j - 1]);

            }
        }

        return absDiff;
    }

    private static BigInteger[][] InputArray(int n)
    {
        BigInteger[][] seq = new BigInteger[n][];

        for (int i = 0; i < n; i++)
        {
            string[] curentline = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            seq[i] = new BigInteger[curentline.Length];

            for (int j = 0; j < curentline.Length; j++)
            {
                seq[i][j] = BigInteger.Parse(curentline[j]);
            }
        }

        return seq;
    }
}

