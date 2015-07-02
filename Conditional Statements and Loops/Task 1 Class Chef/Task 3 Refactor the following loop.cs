using System;

namespace Task_1_Class_Chef
{
    class Task_3_Refactor_the_following_loop
    {
        public static void Loop(int[] numbers, int expectedValue)
        {
            bool isFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentValue = numbers[i];

                if(currentValue==expectedValue)
                {
                    isFound = true;
                }

                Console.WriteLine(currentValue);
            }

            if(isFound)
            {
                Console.WriteLine("Expexted value is found");
            }
        }
    }
}
