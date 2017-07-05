using System;

namespace num_literals
{
    public enum DaysOfWeek
    {
        Sunday      = 0b0000001, // 1 << 0 
        Monday      = 0b0000010, // 1 << 1
        Tuesday     = 0b0000100, // 1 << 2
        Wednesday   = 0b0001000, // 1 << 3
        Thursday    = 0b0010000, // 1 << 4
        Friday      = 0b0100000, // 1 << 5
        Saturday    = 0b1000000, // 1 << 6
        
        All         = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday,
        WorkDays    = Sunday | Monday | Tuesday | Wednesday | Thursday,
        WeekEnds    = Friday | Saturday

    }
    class Program
    {
        public const int One = 0b0001;
        public const int Two = 0b0010;
        public const int Four = 0b0100;
        public const int Eight = 0b1000;
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
