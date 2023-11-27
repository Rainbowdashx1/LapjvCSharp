namespace LapjvCSharp.Business
{
    public class LapjvInternal
    {
        readonly LapjvMethods ljvm;
        public LapjvInternal()
        {
            ljvm = new LapjvMethods();
        }
        public int Lapjv(int n, double[,] cost, out int[] x, out int[] y)
        {
            int ret;
            int[] freeRows = new int[n];
            double[] v = new double[n];

            x = new int[n];
            y = new int[n];

            ret = ljvm.CcrrtDense(n, cost, freeRows, x, y, v);

            int i = 0;
            while (ret > 0 && i < 2)
            {
                ret = ljvm.CarrDense(n, cost, ret, freeRows, x, y, v);
                i++;
            }

            if (ret > 0)
            {
                ret = ljvm.CaDense(n, cost, ret, freeRows, x, y, v);
            }

            return ret;
        }
    }
}
