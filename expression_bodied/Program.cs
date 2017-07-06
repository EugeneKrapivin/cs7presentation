using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace expression_bodied
{
    class Program
    {
        static void Main(string[] args)
        {
            NewMethod();
            GC.Collect();
        }

        private static void NewMethod()
        {
            var p = new Person(("John", "Doe")); // constructor

            System.Console.WriteLine(p.ToString()); // method

            // Setters props
            p.FirstName = "Eugene";
            p.LastName = "Krapivin";

            System.Console.WriteLine($"{p.LastName}, {p.FirstName}"); // getters
            System.Console.WriteLine(p.FullName); // ValueTuple property getter
        }
    }

    public class Person
    {
        private string _fname;
        private string _lname;

        public string FirstName
        {
            get => _fname; // C# 7
            set => _fname = value ?? throw new ArgumentNullException(nameof(FirstName)); // C# 7
        }

        public string LastName
        {
            get => _lname; // C# 7
            set => _lname = value ?? throw new ArgumentNullException(nameof(LastName)); // C# 7
        }

        public override string ToString() => $"{FirstName} {LastName}"; // C# 6

        public (string FirstName, string LastName) FullName => (FirstName, LastName); // C# 6 with ValueTuples

        public Person((string fname, string lname) fullName)
            => (_fname, _lname) = fullName; // C# 7

        ~Person()
            => Console.WriteLine("Good bye, cruel world"); // C# 7
    }
}
