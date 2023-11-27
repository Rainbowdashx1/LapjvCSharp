using LapjvCSharp;

namespace TestLapjvCSharp
{
    public class UnitTest
    {
        readonly Lapjv lap = new Lapjv();
        double[,] Matriz8x8;
        double[,] Matriz4x4;
        double[,] Matriz3x3;
        double[,] Matriz2x2;
        public UnitTest() 
        {
            lap = new Lapjv();
            Matriz8x8 = new double[,]
            { 
                {1000, 2, 11, 10, 8, 7, 6, 5},
                { 6, 1000, 1, 8, 8, 4, 6, 7},
                { 5, 12, 1000, 11, 8, 12, 3, 11},
                { 11, 9, 10, 1000, 1, 9, 8, 10},
                { 11, 11, 9, 4, 1000, 2, 10, 9},
                { 12, 8, 5, 2, 11, 1000, 11, 9},
                { 10, 11, 12, 10, 9, 12, 1000, 3},
                { 10, 10, 10, 10, 6, 3, 1, 1000} 
            };

            Matriz4x4 = new double[,]
            {
                { 10, 6, 14, 1},
                { 17, 18, 17, 15},
                { 14, 17, 15, 8},
                { 11, 13, 11, 4}
            };

            Matriz3x3 = new double[,]
            {
                { 1000, 4, 1},
                { 1, 1000, 3},
                { 5, 1, 1000}
            };

            Matriz2x2 = new double[,]
            {
                { 1f, 0.117f},
                { 1f, 0.730f}
            };
        }

        [Fact]
        public void Test8x8()
        {
            var result = lap.lapjvCsharp(Matriz8x8, true, 4.99);
            int[] x = { 1, 2, -1, 4, 5, 3, 7, 6 };
            int[] y = { -1, 0, 1, 5, 3, 4, 7, 6 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test4x4()
        {
            var result = lap.lapjvCsharp(Matriz4x4, false, double.PositiveInfinity);
            int[] x = { 1, 2, 0, 3 };
            int[] y = { 2, 0, 1, 3 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test3x3()
        {
            var result = lap.lapjvCsharp(Matriz3x3, true, 4);
            int[] x = { 2, 0, 1 };
            int[] y = { 1, 2, 0 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test2x2()
        {
            var result = lap.lapjvCsharp(Matriz2x2, true, 0.80);
            int[] x = { 1, -1 };
            int[] y = { -1, 0 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }
        
    }
}