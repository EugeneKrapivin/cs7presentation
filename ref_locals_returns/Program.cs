using System;

namespace ref_locals_returns
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[10, 10];
            FillMatrix(m);
            PrintMat(m);
            System.Console.Write("\r\n===============================================\r\n");
            
            var (x, y) = m.MyFind(e => e == 42);
            PrintXY(x, y);
            // lets be kinky
            m[x, y] = 24; // not very kinky though...
            PrintMat(m);
            
            System.Console.Write("\r\n===============================================\r\n");
            FillMatrix(m);
            m.MyRefFind(e => e == 24) = 42; // what have we just done?
            PrintMat(m);
        }

        private static void PrintXY(int x, int y) => System.Console.WriteLine($"{x + 1}:{y + 1}");
        
        private static void PrintXY((int x, int y) indices) => PrintXY(indices.x, indices.y);

        private static void PrintMat<T>(T[,] mat)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    System.Console.Write($"{mat[j,i],4}");
                }
                System.Console.WriteLine();
            }
        }

        private static void FillMatrix(int[,] m)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    m[i, j] = (i + 1) * (j + 1);
                }
            }
        }

    }


    public static class Ext
    {
        public static (int i, int j) MyFind<T>(this T[,] matrix, Func<T, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return (i, j);
            return (-1, -1); // Not found
        }

        public static ref T MyRefFind<T>(this T[,] matrix, Func<T, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                    {
                        return ref matrix[i, j];
                    }
                }
            }
            throw new InvalidOperationException("Not found");
        }
    }
}
