namespace LapjvCSharp.Business
{
    public class LapjvInternal
    {
        readonly LapjvMethodsDouble ljvmd;
        readonly LapjvMethodsFloat ljvmf;
        public LapjvInternal()
        {
            ljvmd = new LapjvMethodsDouble();
            ljvmf = new LapjvMethodsFloat();
        }
        public int Lapjv(int n, double[,] cost, out int[] x, out int[] y)
        {
            int ret;
            int[] freeRows = new int[n];
            double[] v = new double[n];

            x = new int[n];
            y = new int[n];

            ret = ljvmd.CcrrtDense(n, cost, freeRows, x, y, v);

            int i = 0;
            while (ret > 0 && i < 2)
            {
                ret = ljvmd.CarrDense(n, cost, ret, freeRows, x, y, v);
                i++;
            }

            if (ret > 0)
            {
                ret = ljvmd.CaDense(n, cost, ret, freeRows, x, y, v);
            }

            return ret;
        }
        public int Lapjv(int n, float[,] cost, out int[] x, out int[] y)
        {
            int ret;
            int[] freeRows = new int[n];
            float[] v = new float[n];

            x = new int[n];
            y = new int[n];

            ret = ljvmf.CcrrtDense(n, cost, freeRows, x, y, v);

            int i = 0;
            while (ret > 0 && i < 2)
            {
                ret = ljvmf.CarrDense(n, cost, ret, freeRows, x, y, v);
                i++;
            }

            if (ret > 0)
            {
                ret = ljvmf.CaDense(n, cost, ret, freeRows, x, y, v);
            }

            return ret;
        }
        public double[,] ExtendCostMatrix(double[,] cost, bool extendCost, double costLimit)
        {
            int nRows = cost.GetLength(0);
            int nCols = cost.GetLength(1);
            int n = nRows;

            if (extendCost || costLimit < double.PositiveInfinity)
            {
                n = nRows + nCols;
                double[,] extendedCost = new double[n, n];
                double defaultValue = costLimit < double.PositiveInfinity ? costLimit / 2.0 : MaxValue(cost) + 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        extendedCost[i, j] = defaultValue;
                    }
                }
                for (int i = nRows; i < n; i++)
                {
                    for (int j = nCols; j < n; j++)
                    {
                        extendedCost[i, j] = 0;
                    }
                }
                for (int i = 0; i < nRows; i++)
                {
                    for (int j = 0; j < nCols; j++)
                    {
                        extendedCost[i, j] = cost[i, j];
                    }
                }
                return extendedCost;
            }
            return cost;
        }
        public float[,] ExtendCostMatrix(float[,] cost, bool extendCost, float costLimit)
        {
            int nRows = cost.GetLength(0);
            int nCols = cost.GetLength(1);
            int n = nRows;

            if (extendCost || costLimit < float.PositiveInfinity)
            {
                n = nRows + nCols;
                float[,] extendedCost = new float[n, n];
                float defaultValue = costLimit < float.PositiveInfinity ? costLimit / 2.0f : MaxValue(cost) + 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        extendedCost[i, j] = defaultValue;
                    }
                }
                for (int i = nRows; i < n; i++)
                {
                    for (int j = nCols; j < n; j++)
                    {
                        extendedCost[i, j] = 0;
                    }
                }
                for (int i = 0; i < nRows; i++)
                {
                    for (int j = 0; j < nCols; j++)
                    {
                        extendedCost[i, j] = cost[i, j];
                    }
                }
                return extendedCost;
            }
            return cost;
        }
        private float MaxValue(float[,] matrix)
        {
            float maxVal = float.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                    }
                }
            }
            return maxVal;
        }
        private double MaxValue(double[,] matrix)
        {
            double maxVal = double.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                    }
                }
            }
            return maxVal;
        }
    }
}
