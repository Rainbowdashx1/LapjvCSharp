namespace LapjvCSharp.Interface
{
    internal interface ILapjv
    {
        (int[] x, int[] y) lapjvCsharp(double[,] cost, bool extendCost = false, double costLimit = double.PositiveInfinity);
        (int[] x, int[] y) lapjvCsharp(float[,] cost, bool extendCost = false, float costLimit = float.PositiveInfinity);
    }
}
