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

### Benchmark Performance

The following benchmarks compare the performance of methods using `float` and `double` for solving matrices of varying sizes. 

#### System Specifications:
- **Processor**: Intel Core i7-8700 CPU @ 3.20GHz (Coffee Lake)
- **Cores**: 6 physical, 12 logical
- **OS**: Windows 10 (22H2/2022 Update)
- **.NET Version**: .NET 8.0.7
- **Benchmark Framework**: BenchmarkDotNet v0.14.0

#### Benchmark Results:

| Method          | Matrix Size | Mean (ns) | Error (ns) | StdDev (ns) |
|---------------- |------------ |----------:|-----------:|------------:|
| SolveWithDouble | 100         | 25.53     | 0.540      | 1.548       |
| SolveWithFloat  | 100         | 24.11     | 0.306      | 0.287       |
| SolveWithDouble | 500         | 23.46     | 0.469      | 0.502       |
| SolveWithFloat  | 500         | 23.54     | 0.405      | 0.379       |
| SolveWithDouble | 1000        | 24.41     | 0.236      | 0.209       |
| SolveWithFloat  | 1000        | 22.89     | 0.164      | 0.128       |
| SolveWithDouble | 2000        | 22.92     | 0.322      | 0.302       |
| SolveWithFloat  | 2000        | 23.17     | 0.165      | 0.146       |

# Changelog
* **Version 1.0.0**: Initial release of the project.
* **Version 1.0.1**: Bugfix by `jmurphyct` to handle 1x2 matrices correctly.
* **Version 1.0.2**: Added support for matrices using `float` instead of `double`. Methods for `double` were duplicated to avoid potential performance issues due to type transformations.