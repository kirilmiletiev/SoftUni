namespace _8.Recursive_Fibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        private static long[] m;

        public static void Main()
        {
            var num = long.Parse(Console.ReadLine());
            m = new long[num + 1];
            Console.WriteLine(GetCalc(num));
        }

        private static long GetCalc(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (m[n] == 0)
            {
                m[n] = GetCalc(n - 1) + GetCalc(n - 2);
            }

            return m[n];
        }
    }
}
