using System;
using System.Collections.Generic;
using System.Linq;

namespace Clonium.Core.General
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> collection)
        {
            int count = collection.Count();
            var random = new Random();
            int randomIndex = random.Next(0, count);

            return collection.ElementAt(randomIndex);
        }

        public static (int maxValue, int row, int col) Max(this int[,] arr)
        {
            int maxElement = int.MinValue;
            int row = 0;
            int col = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > maxElement)
                    {
                        maxElement = arr[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            
            foreach (int i in arr)
            {
                if (i > maxElement)
                    maxElement = i;
            }

            return (maxElement, row, col);
        }
    }
}