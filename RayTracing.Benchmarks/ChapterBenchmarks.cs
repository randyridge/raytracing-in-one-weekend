using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class ChapterBenchmarks {
        private readonly Frame frame = new Frame(200, 100);

        [Benchmark]
        public void Chapter02_FillFrame() => Chapter02.FillFrame(frame);

        [Benchmark]
        public void Chapter04_FillFrame() => Chapter04.FillFrame(frame);

        [Benchmark]
        public void Chapter05_FillFrame() => Chapter05.FillFrame(frame);
    }
}
