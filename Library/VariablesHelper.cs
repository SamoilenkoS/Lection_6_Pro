using System;

namespace Library
{
    public class VariablesHelper
    {
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static int GetCoordinateQuater(int x, int y)
        {
            if(x == 0 || y == 0)
            {
                throw new ArgumentException();
            }

            int result;
            if (x > 0 && y > 0)
            {
                result = 1;
            }
            else if (x > 0 && y < 0)
            {
                result = 2;
            }
            else if (x < 0 && y < 0)
            {
                result = 3;
            }
            else
            {
                result = 4;
            }

            return result;
        }

        public static int GetMinIndexOfArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            int minIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static int IndexOf(int[] array, int searchedElement)
        {
            if(array == null)
            {
                throw new ArgumentException();
            }

            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == searchedElement)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public static int[] GetMaxIndexOfMatrix(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException();
            }

            int xMaxIndex = 0;
            int yMaxIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[xMaxIndex, yMaxIndex])
                    {
                        xMaxIndex = i;
                        yMaxIndex = j;
                    }
                }
            }

            int[] array = new int[] { xMaxIndex, yMaxIndex };

            return (array);
        }

        //2.	Find the maximum element of an array
        public static int GetMaxElementOfMatrix(int[,] matrix)
        {
            int[] array = GetMaxIndexOfMatrix(matrix);

            int result = matrix[array[0], array[1]];

            return result;
        }

        public static void Sort(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) ; j++)
                {
                    for (int k = i; k < matrix.GetLength(0); k++)
                    {
                        for (int l = j; l < matrix.GetLength(1); l++)
                        {
                            if (matrix[i, j] > matrix[k, l])
                            {
                                Swap(ref matrix[i, j], ref matrix[k, l]);
                            }
                        }
                    }
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
