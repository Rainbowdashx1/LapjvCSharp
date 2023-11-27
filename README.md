# lap: Linear Assignment Problem solver
Original package https://github.com/gatagat/lap, made for Python and translated to C# by RainBowDash.

[![Version](https://img.shields.io/nuget/v/LapjvCSharp)](https://www.nuget.org/packages/LapjvCSharp)
[![License](https://img.shields.io/github/license/Rainbowdashx1/LapjvCSharp)](https://github.com/Rainbowdashx1/LapjvCSharp/blob/master/LICENSE.md)

Params
* `cost - type double[,]` 
*  `extendCost - type bool` `default : false`
*  `costLimit - type double` `default : double.PositiveInfinity`

# Use
It can be used as an instance or as dependency injection.
```csharp
    private static void Main(string[] args)
    {
        LapjvCSharp.Lapjv lap = new LapjvCSharp.Lapjv();

        var Matriz8x8 = new double[,]
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

        var result = lap.lapjvCsharp(Matriz8x8, true, 4.99);
    }
```
If a cost_limit is not required for your calculation, use:
```csharp
    private static void Main(string[] args)
    {
        LapjvCSharp.Lapjv lap = new LapjvCSharp.Lapjv();

        var Matriz8x8 = new double[,]
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

        var result = lap.lapjvCsharp(Matriz8x8);
    }
```
