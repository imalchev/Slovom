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

## Licensing
MIT License

## Reference
The library is aware of [gramatical gender](https://en.wikipedia.org/wiki/Grammatical_gender).

The library supports spelling ordinal numbers.

Some info about names of big numbers [wikipedia](https://bg.wikipedia.org/wiki/%D0%98%D0%BC%D0%B5%D0%BD%D0%B0_%D0%BD%D0%B0_%D1%87%D0%B8%D1%81%D0%BB%D0%B0%D1%82%D0%B0).
