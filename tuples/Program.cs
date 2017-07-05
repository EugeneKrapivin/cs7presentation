using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
        #region how do you swap 2 variables?
            int x = 6;
            int y = 8;
            System.Console.WriteLine($"{x} {y}");
            (x, y) = (y, x); // single line swap, no heap allocations
            System.Console.WriteLine($"{x} {y}");
        #endregion
        #region demo
            // deconstruct into max/min vars
            var (max, min) = new[] { "a", "b", "c", "d", "e" }.Extremes();

            PrintExtremes((max, min));

            // assign to variable of type ValueTuple
            var d = new[] { 1, 2, 3, 4, 5 }.Extremes();
            //System.Console.WriteLine(d.GetType());
            PrintExtremes(d);

            // specify type
            (double a, double b) = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 }.Extremes();
            PrintExtremes((a, b));
        #endregion
        #region deconstruct class
            // deconstruct class and rename parameters
            var (fname, lname) = new Person 
            { FirstName = "Eugene", 
            LastName = "Krapivin" };
            System.Console.WriteLine($"We've deconstructed a Person class: {fname}, {lname}");

            // discard operator
            (_, lname) = new Person { FirstName = "Eugene", LastName = "Krapivin" };
            System.Console.WriteLine($"Hello Mr. {lname}");
        #endregion
        #region exceptionless
            // exception-less programming

            var (value, err) = Int.SafeParse(null);
            if (err != null)
            {
                System.Console.WriteLine($"{err}");
            }
            // they are already declared!
            (value, err) = Int.SafeParse("probably wont parse");
            if (err != null)
            {
                System.Console.WriteLine($"{err}");
            }

            (value, err) = Int.SafeParse("123");
            if (err != null)
            {
                System.Console.WriteLine($"{err}");
            }
            System.Console.WriteLine($"The parsed value is {value} and not a single exception was thrown that day...");
        #endregion
        }

        public static void PrintExtremes<T>((T Max, T Min) data) => System.Console.WriteLine($"min: {data.Min} max: {data.Max}");
    }

    public static class EnumExtensions
    {
        public static (T Max, T Min) Extremes<T>(this IEnumerable<T> source) where T : IComparable
        {
            T min = source.First();
            T max = source.First();
            foreach (IComparable n in source)
            {
                min = (n.CompareTo(min)) < 0 ? (T)n : min;
                max = (n.CompareTo(max)) > 0 ? (T)n : max;
            }
            return (max, min);
        }
    }

    public static class Int
    {
        public static (int value, Exception err) SafeParse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return (-1, new ArgumentNullException(nameof(value)));
            }

            if (int.TryParse(value, out var i))
            {
                return (i, null);
            }

            return (-1, new ArgumentException("Failed to parse value"));
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Deconstruct(out string firstName, 
            out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}
