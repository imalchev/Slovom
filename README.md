# Slovom
[![Build status](https://ci.appveyor.com/api/projects/status/s0vgb4m8tv9ar7we?svg=true)](https://ci.appveyor.com/project/imalchev/slovom) [![NuGet](https://img.shields.io/nuget/v/Slovom.svg)](https://www.nuget.org/packages/Slovom)

## General
`Slovom` is small .net library for spelling numbers in Bulgarian language.
The library have no external dependencies.
It is build upon `.net standard 1.0`, `.net standard 2.0`, `.net standard 2.1` and `.net full framework 4.5`

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
Using the library is extremely easy:
	
```cs
INumberSpeller speller = new BgNumberSpeller();

string neutral = speller.Spell(number); // spells the number in a neutral gender

string female = speller.Spell(number, Gender.Female); // spells the number in female gender

string ordinal = speller.SpellOrdinal(number, Gender.Male); // spells number ordinal 
```

## Perforamnce

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.17763.805 (1809/October2018Update/Redstone5)
AMD Ryzen 7 3700X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  Job-QLWSMO : .NET Framework 4.8 (4.8.4018.0), X64 RyuJIT
  Job-SAPYYF : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  Job-EHTIZJ : .NET CoreRT 1.0.28308.01 @BuiltBy: dlab14-DDVSOWINAGE101 @Branch: master @Commit: 9a30f4b28cbba5d3f074a10e05fc63c537308ad7, X64 AOT

```
|            Method |       Runtime |              Number |      Mean |     Error |   StdDev | Ratio | RatioSD | Rank |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------ |-------------- |-------------------- |----------:|----------:|---------:|------:|--------:|-----:|-------:|-------:|------:|----------:|
|             **Spell** |    **.NET 4.7.2** |         **-2147483648** | **500.78 ns** |  **6.394 ns** | **5.981 ns** |  **1.00** |    **0.00** |    **2** | **1.7376** |      **-** |     **-** |    **2279 B** |
|             Spell | .NET Core 3.0 |         -2147483648 | 507.10 ns |  9.873 ns | 9.697 ns |  1.01 |    0.02 |    2 | 0.2651 |      - |     - |    2224 B |
|             Spell |    CoreRt 3.0 |         -2147483648 | 433.47 ns |  2.512 ns | 2.227 ns |  0.87 |    0.01 |    1 | 0.2656 | 0.0005 |     - |    2224 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 |         -2147483648 | 499.91 ns |  7.593 ns | 7.103 ns |  1.00 |    0.00 |    3 | 1.7376 |      - |     - |    2279 B |
| SpellFemaleGender | .NET Core 3.0 |         -2147483648 | 482.57 ns |  1.775 ns | 1.482 ns |  0.97 |    0.01 |    2 | 0.2651 |      - |     - |    2224 B |
| SpellFemaleGender |    CoreRt 3.0 |         -2147483648 | 435.97 ns |  2.908 ns | 2.720 ns |  0.87 |    0.01 |    1 | 0.2656 | 0.0005 |     - |    2224 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
|             **Spell** |    **.NET 4.7.2** |             **-235235** | **257.34 ns** |  **3.102 ns** | **2.750 ns** |  **1.00** |    **0.00** |    **2** | **0.7648** |      **-** |     **-** |    **1003 B** |
|             Spell | .NET Core 3.0 |             -235235 | 255.91 ns |  1.606 ns | 1.341 ns |  0.99 |    0.01 |    2 | 0.1154 |      - |     - |     968 B |
|             Spell |    CoreRt 3.0 |             -235235 | 222.33 ns |  1.637 ns | 1.531 ns |  0.86 |    0.01 |    1 | 0.1156 |      - |     - |     968 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 |             -235235 | 258.00 ns |  1.055 ns | 0.935 ns |  1.00 |    0.00 |    2 | 0.7648 |      - |     - |    1003 B |
| SpellFemaleGender | .NET Core 3.0 |             -235235 | 256.11 ns |  1.712 ns | 1.602 ns |  0.99 |    0.01 |    2 | 0.1154 |      - |     - |     968 B |
| SpellFemaleGender |    CoreRt 3.0 |             -235235 | 224.65 ns |  0.896 ns | 0.795 ns |  0.87 |    0.00 |    1 | 0.1156 |      - |     - |     968 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
|             **Spell** |    **.NET 4.7.2** |                   **1** |  **27.00 ns** |  **0.085 ns** | **0.079 ns** |  **1.00** |    **0.00** |    **3** | **0.0245** |      **-** |     **-** |      **32 B** |
|             Spell | .NET Core 3.0 |                   1 |  26.65 ns |  0.078 ns | 0.069 ns |  0.99 |    0.00 |    2 | 0.0038 |      - |     - |      32 B |
|             Spell |    CoreRt 3.0 |                   1 |  25.71 ns |  0.080 ns | 0.075 ns |  0.95 |    0.01 |    1 | 0.0038 |      - |     - |      32 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 |                   1 |  26.89 ns |  0.092 ns | 0.086 ns |  1.00 |    0.00 |    1 | 0.0245 |      - |     - |      32 B |
| SpellFemaleGender | .NET Core 3.0 |                   1 |  27.00 ns |  0.108 ns | 0.096 ns |  1.00 |    0.00 |    1 | 0.0038 |      - |     - |      32 B |
| SpellFemaleGender |    CoreRt 3.0 |                   1 |  27.62 ns |  0.153 ns | 0.143 ns |  1.03 |    0.01 |    2 | 0.0038 |      - |     - |      32 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
|             **Spell** |    **.NET 4.7.2** |                **1002** |  **59.45 ns** |  **0.634 ns** | **0.593 ns** |  **1.00** |    **0.00** |    **2** | **0.1162** |      **-** |     **-** |     **152 B** |
|             Spell | .NET Core 3.0 |                1002 |  59.86 ns |  0.427 ns | 0.400 ns |  1.01 |    0.01 |    2 | 0.0172 |      - |     - |     144 B |
|             Spell |    CoreRt 3.0 |                1002 |  56.06 ns |  0.461 ns | 0.432 ns |  0.94 |    0.01 |    1 | 0.0172 |      - |     - |     144 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 |                1002 |  60.41 ns |  0.632 ns | 0.591 ns |  1.00 |    0.00 |    2 | 0.1162 |      - |     - |     152 B |
| SpellFemaleGender | .NET Core 3.0 |                1002 |  58.69 ns |  0.378 ns | 0.316 ns |  0.97 |    0.01 |    1 | 0.0172 |      - |     - |     144 B |
| SpellFemaleGender |    CoreRt 3.0 |                1002 |  57.90 ns |  0.387 ns | 0.323 ns |  0.96 |    0.01 |    1 | 0.0172 |      - |     - |     144 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
|             **Spell** |    **.NET 4.7.2** |               **10000** |  **46.91 ns** |  **0.230 ns** | **0.215 ns** |  **1.00** |    **0.00** |    **2** | **0.0918** |      **-** |     **-** |     **120 B** |
|             Spell | .NET Core 3.0 |               10000 |  43.16 ns |  0.200 ns | 0.187 ns |  0.92 |    0.01 |    1 | 0.0134 |      - |     - |     112 B |
|             Spell |    CoreRt 3.0 |               10000 |  43.94 ns |  0.821 ns | 0.768 ns |  0.94 |    0.02 |    1 | 0.0134 |      - |     - |     112 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 |               10000 |  46.52 ns |  0.132 ns | 0.117 ns |  1.00 |    0.00 |    2 | 0.0918 |      - |     - |     120 B |
| SpellFemaleGender | .NET Core 3.0 |               10000 |  45.06 ns |  0.696 ns | 0.651 ns |  0.97 |    0.01 |    1 | 0.0134 |      - |     - |     112 B |
| SpellFemaleGender |    CoreRt 3.0 |               10000 |  45.34 ns |  0.299 ns | 0.249 ns |  0.97 |    0.01 |    1 | 0.0134 |      - |     - |     112 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
|             **Spell** |    **.NET 4.7.2** |          **4263246324** | **467.03 ns** |  **1.681 ns** | **1.313 ns** |  **1.00** |    **0.00** |    **2** | **1.4935** |      **-** |     **-** |    **1958 B** |
|             Spell | .NET Core 3.0 |          4263246324 | 483.30 ns |  9.560 ns | 8.942 ns |  1.04 |    0.02 |    3 | 0.2265 | 0.0005 |     - |    1896 B |
|             Spell |    CoreRt 3.0 |          4263246324 | 410.73 ns |  5.675 ns | 5.309 ns |  0.88 |    0.01 |    1 | 0.2265 |      - |     - |    1896 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 |          4263246324 | 467.92 ns |  6.027 ns | 5.637 ns |  1.00 |    0.00 |    2 | 1.4935 |      - |     - |    1958 B |
| SpellFemaleGender | .NET Core 3.0 |          4263246324 | 468.28 ns |  2.334 ns | 2.069 ns |  1.00 |    0.01 |    2 | 0.2265 |      - |     - |    1896 B |
| SpellFemaleGender |    CoreRt 3.0 |          4263246324 | 408.05 ns |  2.160 ns | 2.021 ns |  0.87 |    0.01 |    1 | 0.2265 |      - |     - |    1896 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
|             **Spell** |    **.NET 4.7.2** | **9223372036854775807** | **929.21 ns** |  **8.189 ns** | **7.660 ns** |  **1.00** |    **0.00** |    **3** | **3.2377** |      **-** |     **-** |    **4245 B** |
|             Spell | .NET Core 3.0 | 9223372036854775807 | 912.10 ns |  8.501 ns | 7.099 ns |  0.98 |    0.01 |    2 | 0.4921 | 0.0010 |     - |    4120 B |
|             Spell |    CoreRt 3.0 | 9223372036854775807 | 800.59 ns |  6.132 ns | 5.436 ns |  0.86 |    0.01 |    1 | 0.4921 | 0.0010 |     - |    4120 B |
|                   |               |                     |           |           |          |       |         |      |        |        |       |           |
| SpellFemaleGender |    .NET 4.7.2 | 9223372036854775807 | 935.10 ns | 10.007 ns | 9.361 ns |  1.00 |    0.00 |    2 | 3.2377 |      - |     - |    4245 B |
| SpellFemaleGender | .NET Core 3.0 | 9223372036854775807 | 937.46 ns |  7.143 ns | 6.682 ns |  1.00 |    0.01 |    2 | 0.4921 | 0.0010 |     - |    4120 B |
| SpellFemaleGender |    CoreRt 3.0 | 9223372036854775807 | 796.29 ns |  3.946 ns | 3.498 ns |  0.85 |    0.01 |    1 | 0.4921 | 0.0010 |     - |    4120 B |

## Licensing
MIT License

## Reference
The library is aware of [grammatical gender](https://en.wikipedia.org/wiki/Grammatical_gender).

The library supports spelling ordinal numbers.

Some info about names of big numbers [wikipedia](https://bg.wikipedia.org/wiki/%D0%98%D0%BC%D0%B5%D0%BD%D0%B0_%D0%BD%D0%B0_%D1%87%D0%B8%D1%81%D0%BB%D0%B0%D1%82%D0%B0).
