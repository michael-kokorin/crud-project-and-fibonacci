using System;

namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CalcFibonacci(100));
            Console.ReadLine();
        }

        public static long CalcFibonacci(int itemNumber)
        {
            if (itemNumber <= 0)
            {
                throw new InvalidOperationException("itemNumber is not valid");
            }

            if (itemNumber == 1 || itemNumber == 2)
            {
                return 1;
            }

            var itemMinusOne = 1L;
            var currentItem = 1L;
            for (var index = 0; index < itemNumber - 2; index++)
            {
                var nextItem = itemMinusOne + currentItem;
                itemMinusOne = currentItem;
                currentItem = nextItem;
            }

            return currentItem;
        }
    }
}
