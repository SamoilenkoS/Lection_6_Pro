using System;
using System.IO;

namespace FilesAndUTConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintEachSecondLine();
            var source = @"C:\Users\Sviatoslav_Samoilenk\Desktop\Test\source.txt";
            var dest = @"C:\Users\Sviatoslav_Samoilenk\Desktop\Test\dest.txt";
            //var matrix = GenerateMatrix(5);
            //WriteMatrixToFile(path, matrix);
            //Print("Hello", "Hello world", "Test data");

        }

        private static void CopyFromOneFileToAnother(string source, string dest)
        {
            using (var streamReader = new StreamReader(source))
            {
                using (var streamWriter = new StreamWriter(dest))
                {
                    while (!streamReader.EndOfStream)
                    {
                        streamWriter.WriteLine(streamReader.ReadLine());
                    }
                }
            }
        }

        private static void ReadWriteExamples(string path)
        {
            int[] array;
            using (var streamReader = new StreamReader(path))
            {
                var input = streamReader.ReadToEnd();
                string[] items = input.Split(
                    new char[] { ' ', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);
                array = new int[items.Length];
                int i = 0;
                foreach (var item in items)
                {
                    array[i++] = Convert.ToInt32(item);
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }

        public static void Print(params string[] items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static double Max(double a, double b)
        {
            return a > b ? a : b;
        }

        private static void WriteMatrixToFile(string path, int[,] matrix)
        {
            using (var streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine();
                foreach (var item in matrix)
                {
                    streamWriter.Write($"{item} ");
                }
            }
        }

        private static void PrintEachSecondLine(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                int count = 1;
                while (!streamReader.EndOfStream)
                {
                    string input = streamReader.ReadLine();
                    if (count % 2 == 0)
                    {
                        Console.WriteLine(input);
                    }

                    ++count;
                }
            }
        }

        static int[,] GenerateMatrix(int size = 3)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(10, 50);
                }
            }

            return matrix;
        }

        static void TestMain()
        {
            var matrix = GenerateMatrix();

            PrintMatrix(matrix);

            (int, int) result = MinIndexNew(matrix);
            Console.WriteLine(result);
            Console.WriteLine();

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }

                Console.WriteLine();
            }
        }

        public static (int minI, int minJ) MinIndex(int[,] matrix)
        {
            if(matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException();
            }

            (int minI, int minJ) result = (0, 0);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j] < matrix[result.minI, result.minJ])
                    {
                        result = (i, j);
                    }
                }
            }

            return result;
        }

        public static (int MinIndexMatrixRow, int MinIndexMatrix) MinIndexNew(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException("Empty or null array!");
            }

            int MinIndexMatrixRow = 0;
            int MinIndexMatrix = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[MinIndexMatrixRow, MinIndexMatrix] > matrix[i, j])
                    {
                        MinIndexMatrix = j;
                        MinIndexMatrixRow = i;
                    }
                }
            }
            return (MinIndexMatrixRow, MinIndexMatrix);
        }
    }
}
