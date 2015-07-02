namespace Printer
{
    using System;

    public class Print
    {
        private const int MaxCount = 6;

        public class RenderBulean
        {
            public void Render(bool value)
            {
                string valueToSting = value.ToString();
                Console.WriteLine(valueToSting);
            }
        }
    }
}