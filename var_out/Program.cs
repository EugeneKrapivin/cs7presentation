using System;

namespace var_out
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse("1", out var n);
            System.Console.WriteLine(n);
        }
    }
}
