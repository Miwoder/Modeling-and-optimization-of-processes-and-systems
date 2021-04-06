using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static class MyMethods
    {

        public static float Max(float [] array)
        {
            float max = -1000;

            foreach (var item in array)
            {
                max=item > max ? item : max;
            }

            return max;
        }

        public static float Min(float[] array)
        {
            float min = 1000;

            foreach (var item in array)
            {
                min = item < min ? item : min;
            }

            return min;
        }

        public static int GetIndexMax(float[] array)
        {
            float max = -1000;
            int index=0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }

        public static int GetIndexMin(float[] array)
        {
            float min = 1000;
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }

        public static float CalculationD(float S,float p,float R1,float C1,float R2,float C2)
        {
            return S * (p * (R1 - C1) - (1 - p) * (R2 - C2));
        }

        public static float[] GetColumn(float[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static float[] GetRow(float[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        public static float GetSum(float[] matrix)
        {
            float sum=0f;
            foreach (var item in matrix)
            {
                sum += item;
            }
            return sum;
        }

        public static double[] GaussMethod(float[,]data)
        {
            int n = data.GetLength(0);
            double c, sum = 0.0;
            double[] x = new double[n];

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i > j)
                    {
                        c = data[i, j] / data[j, j];
                        for (int k = 0; k < n + 1; k++)
                        {
                            data[i, k] = data[i, k] - (float)c * data[j, k];
                        }
                    }
                }
            }

            x[n - 1] = data[n - 1, n] / data[n - 1, n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum = sum + data[i, j] * x[j];
                }
                x[i] = (data[i, n] - sum) / data[i, i];
            }

            return x;
        }

    }
}
