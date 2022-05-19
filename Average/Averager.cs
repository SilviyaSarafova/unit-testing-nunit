using System;

namespace Averager
{
    public class Averager
    {
        public double Average(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return Math.Round(sum / arr.Length, 2);
        }
    }
}
