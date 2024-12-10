using LapjvCSharp.Business;
using LapjvCSharp.Interface;
using System;

namespace LapjvCSharp
{
    public class Lapjv : ILapjv
    {
        readonly LapjvInternal lap;
        readonly LapjvMethods lapm;
        public Lapjv()
        {
            lap = new LapjvInternal();
            lapm = new LapjvMethods();
        }

        public (int[] x, int[] y) lapjvCsharp(double[,] cost, bool extendCost = false, double costLimit = double.PositiveInfinity)
        {
            int rows = cost.GetLength(0);
            int cols = cost.GetLength(1);
            int n = rows;

            if (extendCost)
                n = rows + cols;

            int[] x, y;

            cost = lapm.ExtendCostMatrix(cost, extendCost, costLimit);
            lap.Lapjv(n, cost, out x, out y);

            if (n != rows)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] >= cols) x[i] = -1;
                }
                for (int i = 0; i < y.Length; i++)
                {
                    if (y[i] >= rows) y[i] = -1;
                }
            }
            Array.Resize(ref x, rows);
            Array.Resize(ref y, cols);

            return (x, y);
        }
    }
}
