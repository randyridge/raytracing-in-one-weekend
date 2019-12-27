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

        [Benchmark]
        public void Chapter06a_FillFrame() => Chapter06a.FillFrame(frame);

        [Benchmark]
        public void Chapter06b_FillFrame() => Chapter06b.FillFrame(frame);

        [Benchmark]
        public void Chapter07_FillFrame() => Chapter07.FillFrame(frame);

        [Benchmark]
        public void Chapter08a_FillFrame() => Chapter08a.FillFrame(frame);

        [Benchmark]
        public void Chapter08b_FillFrame() => Chapter08b.FillFrame(frame);
    }
}
