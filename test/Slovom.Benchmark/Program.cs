using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Slovom.Benchmark
{
    [ClrJob(baseline: true), CoreJob, CoreRtJob]
    [RPlotExporter, RankColumn]
    public class Speller
    {
        private INumberSpeller _speller = new BgNumberSpeller();

        [Params(1, 1_002, 10_000, 4_263_246_324, long.MaxValue, -235_235, int.MinValue)]
        public long Number;

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public string Spell() => _speller.Spell(Number);

        [Benchmark]
        public string SpellFemaleGender() => _speller.Spell(Number, Gender.Female);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Speller>();
        }
    }
}
