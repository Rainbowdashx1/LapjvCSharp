namespace LapjvCSharp.Interface
{
    internal interface ILapjv
    {
        (int[] x, int[] y) lapjvCsharp(double[,] cost, bool extendCost = false, double costLimit = double.PositiveInfinity);
    }
}
