using LapjvCSharp;

namespace TestLapjvCSharp
{
    public class UnitTest
    {
        readonly Lapjv lap = new Lapjv();

        double[,] Matriz8x8d;
        double[,] Matriz4x4d;
        double[,] Matriz3x3d;
        double[,] Matriz2x2d;
        double[,] Matriz1x2d;

        float[,] Matriz8x8f;
        float[,] Matriz4x4f;
        float[,] Matriz3x3f;
        float[,] Matriz2x2f;
        float[,] Matriz1x2f;
        public UnitTest()
        {
            lap = new Lapjv();

            Matriz8x8d = new double[,]
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

            Matriz4x4d = new double[,]
            {
                { 10, 6, 14, 1},
                { 17, 18, 17, 15},
                { 14, 17, 15, 8},
                { 11, 13, 11, 4}
            };

            Matriz3x3d = new double[,]
            {
                { 1000, 4, 1},
                { 1, 1000, 3},
                { 5, 1, 1000}
            };

            Matriz2x2d = new double[,]
            {
                { 1, 0.117},
                { 1, 0.730}
            };

            Matriz1x2d = new double[,]
            {
                { -0.936, -0.31},
            };

            /**************Float Matrix**************************/

            Matriz8x8f = new float[,]
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

            Matriz4x4f = new float[,]
            {
                { 10, 6, 14, 1},
                { 17, 18, 17, 15},
                { 14, 17, 15, 8},
                { 11, 13, 11, 4}
            };

            Matriz3x3f = new float[,]
            {
                { 1000, 4, 1},
                { 1, 1000, 3},
                { 5, 1, 1000}
            };

            Matriz2x2f = new float[,]
            {
                { 1f, 0.117f},
                { 1f, 0.730f}
            };

            Matriz1x2f = new float[,]
            {
                { -0.936f, -0.31f},
            };
        }

        [Fact]
        public void Test8x8()
        {
            var result = lap.lapjvCsharp(Matriz8x8d, true, 4.99);
            int[] x = { 1, 2, -1, 4, 5, 3, 7, 6 };
            int[] y = { -1, 0, 1, 5, 3, 4, 7, 6 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test4x4()
        {
            var result = lap.lapjvCsharp(Matriz4x4d, false, double.PositiveInfinity);
            int[] x = { 1, 2, 0, 3 };
            int[] y = { 2, 0, 1, 3 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test3x3()
        {
            var result = lap.lapjvCsharp(Matriz3x3d, true, 4);
            int[] x = { 2, 0, 1 };
            int[] y = { 1, 2, 0 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test2x2()
        {
            var result = lap.lapjvCsharp(Matriz2x2d, true, 0.80);
            int[] x = { 1, -1 };
            int[] y = { -1, 0 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test2x1()
        {
            var result = lap.lapjvCsharp(Matriz1x2d, true, 0.80);
            int[] x = { 0 };
            int[] y = { 0, -1 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        /***************Float Test************************/

        [Fact]
        public void Test8x8F()
        {
            var result = lap.lapjvCsharp(Matriz8x8f, true, 4.99f);
            int[] x = { 1, 2, -1, 4, 5, 3, 7, 6 };
            int[] y = { -1, 0, 1, 5, 3, 4, 7, 6 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test4x4F()
        {
            var result = lap.lapjvCsharp(Matriz4x4f, false, float.PositiveInfinity);
            int[] x = { 1, 2, 0, 3 };
            int[] y = { 2, 0, 1, 3 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test3x3F()
        {
            var result = lap.lapjvCsharp(Matriz3x3f, true, 4f);
            int[] x = { 2, 0, 1 };
            int[] y = { 1, 2, 0 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test2x2F()
        {
            var result = lap.lapjvCsharp(Matriz2x2f, true, 0.80f);
            int[] x = { 1, -1 };
            int[] y = { -1, 0 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }

        [Fact]
        public void Test2x1F()
        {
            var result = lap.lapjvCsharp(Matriz1x2f, true, 0.80f);
            int[] x = { 0 };
            int[] y = { 0, -1 };

            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
        }
    }
}