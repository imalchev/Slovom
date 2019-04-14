# Slovom
[![Build status](https://ci.appveyor.com/api/projects/status/s0vgb4m8tv9ar7we?svg=true)](https://ci.appveyor.com/project/imalchev/slovom) [![NuGet](https://img.shields.io/nuget/v/Slovom.svg)](https://www.nuget.org/packages/Slovom)

## General
`Slovom` is small .net library for spelling numbers in bulgarian language.
The library have no external dependencies.
It is build upon `.net standard 1.0`, `.net standard 2.0` and `.net full framework 4.5`

## Instalation
You can install Slovom using [NuGet](https://www.nuget.org/packages/Slovom):
```
Install-Package Slovom
```
Or via the .NET Core command line interface:
```
dotnet add package Slovom
```

## Usage
Using the library is extreamly easy:
	
```cs
INumberSpeller speller = new BgNumberSpeller();

string neutral = speller.Spell(number); // spells the number in a neutral gender

string female = speller.Spell(number, Gender.Female); // spells the number in female gender

string ordinal = speller.SpellOrdinal(number, Gender.Male); // spells number ordinal 
```

## Perforamnce

``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i5-3230M CPU 2.60GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.105
  [Host] : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Core   : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  CoreRT : .NET CoreRT 1.0.27527.01 @BuiltBy: dlab14-DDVSOWINAGE101 @Branch: master @Commit: bd07c4e0727fa104d50e28ed70ca9bb480dcbc1b, 64bit AOT


```
|            Method |    Job | Runtime |              Number |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD | Rank |
|------------------ |------- |-------- |-------------------- |------------:|----------:|----------:|------------:|------:|--------:|-----:|
|             **Spell** |    **Clr** |     **Clr** |         **-2147483648** | **1,016.06 ns** | **16.317 ns** | **14.465 ns** | **1,016.69 ns** |  **1.00** |    **0.00** |    **1** |
|             Spell |   Core |    Core |         -2147483648 | 1,284.87 ns | 25.823 ns | 60.869 ns | 1,268.86 ns |  1.31 |    0.07 |    2 |
|             Spell | CoreRT |  CoreRT |         -2147483648 | 1,032.39 ns | 22.565 ns | 18.843 ns | 1,025.03 ns |  1.02 |    0.02 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr |         -2147483648 | 1,229.31 ns | 24.646 ns | 59.991 ns | 1,220.80 ns |  1.00 |    0.00 |    2 |
| SpellFemaleGender |   Core |    Core |         -2147483648 | 1,259.07 ns | 22.465 ns | 19.915 ns | 1,257.73 ns |  1.06 |    0.09 |    3 |
| SpellFemaleGender | CoreRT |  CoreRT |         -2147483648 | 1,034.77 ns | 29.322 ns | 27.428 ns | 1,030.57 ns |  0.87 |    0.07 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
|             **Spell** |    **Clr** |     **Clr** |             **-235235** |   **631.59 ns** | **30.357 ns** | **85.124 ns** |   **606.30 ns** |  **1.00** |    **0.00** |    **2** |
|             Spell |   Core |    Core |             -235235 |   583.69 ns | 10.224 ns |  8.538 ns |   580.08 ns |  0.93 |    0.13 |    2 |
|             Spell | CoreRT |  CoreRT |             -235235 |   475.13 ns |  3.792 ns |  3.547 ns |   474.65 ns |  0.75 |    0.10 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr |             -235235 |   566.16 ns | 11.207 ns | 11.007 ns |   563.20 ns |  1.00 |    0.00 |    2 |
| SpellFemaleGender |   Core |    Core |             -235235 |   588.63 ns | 11.498 ns | 12.303 ns |   584.97 ns |  1.04 |    0.02 |    3 |
| SpellFemaleGender | CoreRT |  CoreRT |             -235235 |   535.75 ns | 21.356 ns | 61.273 ns |   511.48 ns |  0.97 |    0.13 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
|             **Spell** |    **Clr** |     **Clr** |                   **1** |    **60.45 ns** |  **1.331 ns** |  **2.150 ns** |    **60.22 ns** |  **1.00** |    **0.00** |    **2** |
|             Spell |   Core |    Core |                   1 |    65.29 ns |  1.447 ns |  2.337 ns |    64.48 ns |  1.08 |    0.06 |    3 |
|             Spell | CoreRT |  CoreRT |                   1 |    52.45 ns |  1.709 ns |  2.223 ns |    51.83 ns |  0.87 |    0.05 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr |                   1 |    57.04 ns |  1.278 ns |  2.696 ns |    56.11 ns |  1.00 |    0.00 |    1 |
| SpellFemaleGender |   Core |    Core |                   1 |    64.86 ns |  1.168 ns |  1.036 ns |    64.95 ns |  1.08 |    0.06 |    2 |
| SpellFemaleGender | CoreRT |  CoreRT |                   1 |    64.08 ns |  2.827 ns |  8.200 ns |    63.19 ns |  1.14 |    0.18 |    2 |
|                   |        |         |                     |             |           |           |             |       |         |      |
|             **Spell** |    **Clr** |     **Clr** |                **1002** |   **169.20 ns** |  **4.064 ns** | **10.919 ns** |   **168.24 ns** |  **1.00** |    **0.00** |    **2** |
|             Spell |   Core |    Core |                1002 |   169.75 ns |  3.496 ns |  3.740 ns |   168.76 ns |  1.01 |    0.05 |    2 |
|             Spell | CoreRT |  CoreRT |                1002 |   129.21 ns |  1.403 ns |  1.244 ns |   129.03 ns |  0.77 |    0.04 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr |                1002 |   170.82 ns |  3.540 ns |  4.602 ns |   169.43 ns |  1.00 |    0.00 |    3 |
| SpellFemaleGender |   Core |    Core |                1002 |   143.26 ns |  1.861 ns |  1.554 ns |   142.85 ns |  0.84 |    0.02 |    2 |
| SpellFemaleGender | CoreRT |  CoreRT |                1002 |   127.31 ns |  1.375 ns |  1.286 ns |   127.17 ns |  0.75 |    0.02 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
|             **Spell** |    **Clr** |     **Clr** |               **10000** |   **116.12 ns** |  **1.996 ns** |  **2.298 ns** |   **115.55 ns** |  **1.00** |    **0.00** |    **2** |
|             Spell |   Core |    Core |               10000 |   115.10 ns |  1.476 ns |  1.309 ns |   114.93 ns |  0.99 |    0.02 |    2 |
|             Spell | CoreRT |  CoreRT |               10000 |   104.75 ns |  1.154 ns |  1.023 ns |   104.41 ns |  0.90 |    0.02 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr |               10000 |   116.35 ns |  1.439 ns |  1.124 ns |   116.71 ns |  1.00 |    0.00 |    2 |
| SpellFemaleGender |   Core |    Core |               10000 |   120.17 ns |  2.552 ns |  4.918 ns |   118.36 ns |  1.05 |    0.05 |    3 |
| SpellFemaleGender | CoreRT |  CoreRT |               10000 |   104.93 ns |  1.602 ns |  1.421 ns |   104.74 ns |  0.90 |    0.02 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
|             **Spell** |    **Clr** |     **Clr** |          **4263246324** | **1,126.78 ns** | **20.616 ns** | **19.284 ns** | **1,128.55 ns** |  **1.00** |    **0.00** |    **2** |
|             Spell |   Core |    Core |          4263246324 | 1,179.06 ns | 21.420 ns | 20.037 ns | 1,176.84 ns |  1.05 |    0.02 |    3 |
|             Spell | CoreRT |  CoreRT |          4263246324 |   980.51 ns | 18.237 ns | 17.059 ns |   983.92 ns |  0.87 |    0.02 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr |          4263246324 | 1,162.81 ns | 23.290 ns | 36.940 ns | 1,155.90 ns |  1.00 |    0.00 |    2 |
| SpellFemaleGender |   Core |    Core |          4263246324 | 1,162.11 ns | 19.349 ns | 17.152 ns | 1,156.62 ns |  0.99 |    0.04 |    2 |
| SpellFemaleGender | CoreRT |  CoreRT |          4263246324 |   973.65 ns | 19.228 ns | 17.986 ns |   974.58 ns |  0.83 |    0.03 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
|             **Spell** |    **Clr** |     **Clr** | **9223372036854775807** | **2,247.79 ns** | **35.644 ns** | **33.341 ns** | **2,255.14 ns** |  **1.00** |    **0.00** |    **2** |
|             Spell |   Core |    Core | 9223372036854775807 | 2,325.08 ns | 40.763 ns | 38.130 ns | 2,311.87 ns |  1.03 |    0.02 |    3 |
|             Spell | CoreRT |  CoreRT | 9223372036854775807 | 1,970.91 ns | 39.267 ns | 59.965 ns | 1,949.59 ns |  0.88 |    0.04 |    1 |
|                   |        |         |                     |             |           |           |             |       |         |      |
| SpellFemaleGender |    Clr |     Clr | 9223372036854775807 | 2,228.39 ns | 34.080 ns | 28.458 ns | 2,226.92 ns |  1.00 |    0.00 |    2 |
| SpellFemaleGender |   Core |    Core | 9223372036854775807 | 2,443.84 ns | 48.778 ns | 45.627 ns | 2,436.71 ns |  1.10 |    0.03 |    3 |
| SpellFemaleGender | CoreRT |  CoreRT | 9223372036854775807 | 1,892.42 ns | 31.617 ns | 28.028 ns | 1,882.46 ns |  0.85 |    0.02 |    1 |

## Licensing
MIT License

## Reference
The library is aware of [gramatical gender](https://en.wikipedia.org/wiki/Grammatical_gender).

The library supports spelling ordinal numbers.

Some info about names of big numbers [wikipedia](https://bg.wikipedia.org/wiki/%D0%98%D0%BC%D0%B5%D0%BD%D0%B0_%D0%BD%D0%B0_%D1%87%D0%B8%D1%81%D0%BB%D0%B0%D1%82%D0%B0).
