namespace People
{
    using System;

    public class People
    {
        public static void Main()
        {
            var female = new Persone();
            female.Age = 25;
            female = female.ConfigurePersone(3);
            var male = new Persone();
            male.Age = 24;
            male = male.ConfigurePersone(2);

            Console.WriteLine(female);
            Console.WriteLine(male);
        }
    }
}