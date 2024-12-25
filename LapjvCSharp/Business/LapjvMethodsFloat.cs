using System;

namespace LapjvCSharp.Business
{
    public class LapjvMethodsFloat
    {
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
        public int CcrrtDense(int n, float[,] cost, int[] freeRows, int[] x, int[] y, float[] v)
        {
            int nFreeRows = 0;
            bool[] unique = new bool[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = -1;
                v[i] = float.MaxValue;
                y[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    float c = cost[i, j];
                    if (c < v[j])
                    {
                        v[j] = c;
                        y[j] = i;
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int j = y[i];
                if (x[j] < 0)
                {
                    x[j] = i;
                }
                else
                {
                    unique[j] = false;
                    y[i] = -1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (x[i] < 0)
                {
                    freeRows[nFreeRows++] = i;
                }
                else if (unique[i])
                {
                    int j = x[i];
                    float min = float.MaxValue;
                    for (int j2 = 0; j2 < n; j2++)
                    {
                        if (j2 == j) continue;
                        float c = cost[i, j2] - v[j2];
                        if (c < min)
                        {
                            min = c;
                        }
                    }
                    v[j] -= min;
                }
            }

            return nFreeRows;
        }
        public int CarrDense(int n, float[,] cost, int nFreeRows, int[] freeRows, int[] x, int[] y, float[] v)
        {
            int current = 0;
            int newFreeRows = 0;
            int rrCnt = 0;
            while (current < nFreeRows)
            {
                int freeI = freeRows[current++];
                int j1 = 0;
                float v1 = cost[freeI, 0] - v[0];
                int j2 = -1;
                float v2 = float.MaxValue;
                for (int j = 1; j < n; j++)
                {
                    float c = cost[freeI, j] - v[j];
                    if (c < v2)
                    {
                        if (c >= v1)
                        {
                            v2 = c;
                            j2 = j;
                        }
                        else
                        {
                            v2 = v1;
                            v1 = c;
                            j2 = j1;
                            j1 = j;
                        }
                    }
                }

                int i0 = y[j1];
                float v1New = v[j1] - (v2 - v1);
                bool v1Lowers = v1New < v[j1];

                if (rrCnt < current * n)
                {
                    if (v1Lowers)
                    {
                        v[j1] = v1New;
                    }
                    else if (i0 >= 0 && j2 >= 0)
                    {
                        j1 = j2;
                        i0 = y[j2];
                    }

                    if (i0 >= 0)
                    {
                        if (v1Lowers)
                        {
                            freeRows[--current] = i0;
                        }
                        else
                        {
                            freeRows[newFreeRows++] = i0;
                        }
                    }
                }
                else
                {
                    if (i0 >= 0)
                    {
                        freeRows[newFreeRows++] = i0;
                    }
                }

                x[freeI] = j1;
                y[j1] = freeI;
                rrCnt++;
            }

            return newFreeRows;
        }
        public int CaDense(int n, float[,] cost, int nFreeRows, int[] freeRows, int[] x, int[] y, float[] v)
        {
            int[] pred = new int[n];

            for (int index = 0; index < nFreeRows; index++)
            {
                int freeI = freeRows[index];
                int i = -1, j = 0;
                int k = 0;

                j = FindPathDense(n, cost, freeI, y, v, pred);
                if (j < 0 || j >= n)
                {
                    throw new InvalidOperationException("Assertion failed: j is out of range");
                }

                while (i != freeI)
                {
                    i = pred[j];
                    y[j] = i;
                    SwapIndices(ref j, ref x[i]);
                    k++;
                    if (k >= n)
                    {
                        throw new InvalidOperationException("Assertion failed: k >= n");
                    }
                }
            }

            return 0;
        }
        private void SwapIndices(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public int FindPathDense(int n, float[,] cost, int startI, int[] y, float[] v, int[] pred)
        {
            int lo = 0, hi = 0;
            int finalJ = -1;
            int nReady = 0;
            int[] cols = new int[n];
            float[] d = new float[n];

            for (int i = 0; i < n; i++)
            {
                cols[i] = i;
                pred[i] = startI;
                d[i] = cost[startI, i] - v[i];
            }

            while (finalJ == -1)
            {
                if (lo == hi)
                {
                    nReady = lo;
                    hi = FindDense(n, lo, d, cols, y);

                    for (int k = lo; k < hi; k++)
                    {
                        int j = cols[k];
                        if (y[j] < 0)
                        {
                            finalJ = j;
                        }
                    }
                }
                if (finalJ == -1)
                {
                    finalJ = ScanDense(n, cost, ref lo, ref hi, d, cols, pred, y, v);
                }
            }

            float mind = d[cols[lo]];
            for (int k = 0; k < nReady; k++)
            {
                int j = cols[k];
                v[j] += d[j] - mind;
            }

            return finalJ;
        }
        public int FindDense(int n, int lo, float[] d, int[] cols, int[] y)
        {
            int hi = lo + 1;
            float mind = d[cols[lo]];

            for (int k = hi; k < n; k++)
            {
                int j = cols[k];
                if (d[j] <= mind)
                {
                    if (d[j] < mind)
                    {
                        hi = lo;
                        mind = d[j];
                    }
                    cols[k] = cols[hi];
                    cols[hi++] = j;
                }
            }

            return hi;
        }

        public int ScanDense(int n, float[,] cost, ref int lo, ref int hi, float[] d, int[] cols, int[] pred, int[] y, float[] v)
        {
            float h, cred_ij;

            while (lo != hi)
            {
                int j = cols[lo++];
                int i = y[j];
                float mind = d[j];
                h = cost[i, j] - v[j] - mind;

                for (int k = hi; k < n; k++)
                {
                    j = cols[k];
                    cred_ij = cost[i, j] - v[j] - h;
                    if (cred_ij < d[j])
                    {
                        d[j] = cred_ij;
                        pred[j] = i;
                        if (cred_ij == mind)
                        {
                            if (y[j] < 0)
                            {
                                return j;
                            }
                            cols[k] = cols[hi];
                            cols[hi++] = j;
                        }
                    }
                }
            }

            lo = lo;
            hi = hi;
            return -1;
        }
    }
}
