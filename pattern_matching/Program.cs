using System;
using System.Collections.Generic;
using System.Linq;

namespace pattern_matching
{
    public struct Multiplier
    {
        public int Num { get; set; }
        public int Mult { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = DiceSum(new[] { 1, 2, 3, 4, 5, 6 });
            System.Console.WriteLine($"No matching sum: {s1}");

            var s2 = DiceSum2(new object[] { 1, 2, 3, 4, 5, 6, new[] { 7, 8, 9, 10 } });
            System.Console.WriteLine($"Type matching sum in if: {s2}");

            var s3 = DiceSum3(new object[] { 1, 2, 3, 4, 5, 6, 
            new[] { 7, 8, 9, 10 } });
            System.Console.WriteLine($"Type matching sum in switch: {s3}");

            var s4 = DiceSum4(new object[] {1,2,3,4,
                new object[] {5,6, new object[] {7,8}},
                Enumerable.Empty<object>(),
                Enumerable.Range(9, 2).Cast<object>() /*,0*/ /*,null*/});
            System.Console.WriteLine($"Type matching sum in switch with filter: {s4}");

            var s5 = DiceSum5(new object[] {1,2,3,
                new Multiplier{Num =2, Mult = 2},
                new object[] {5,6, new object[] {7,8}},
                Enumerable.Empty<object>(),
                Enumerable.Range(9, 2).Cast<object>() /*,0*/ /*,null*/});
            System.Console.WriteLine($"Type matching sum in switch with filter: {s5}");
        }

        public static int DiceSum(IEnumerable<int> values)
        {
            return values.Sum();
        }

        public static int DiceSum2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                if (item is int val)
                    sum += val;
                else if (item is IEnumerable<object> subList)
                    sum += DiceSum2(subList);
            }
            return sum;
        }
        public static int DiceSum3(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList:
                        sum += DiceSum3(subList);
                        break;
                }
            }
            return sum;
        }

        public static int DiceSum4(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSum4(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
            return sum;
        }

        public static int DiceSum5(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case Multiplier multi:
                        sum += multi.Num * multi.Mult;
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSum4(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
            return sum;
        }
    }
}
