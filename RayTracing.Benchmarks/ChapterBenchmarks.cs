using BenchmarkDotNet.Attributes;
using RayTracing.Chapters;
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

        [Benchmark]
        public void Chapter09a_FillFrame() => Chapter09a.FillFrame(frame);

        [Benchmark]
        public void Chapter09b_FillFrame() => Chapter09b.FillFrame(frame);

        [Benchmark]
        public void Chapter10a_FillFrame() => Chapter10a.FillFrame(frame);

        [Benchmark]
        public void Chapter10b_FillFrame() => Chapter10b.FillFrame(frame);

        [Benchmark]
        public void Chapter11a_FillFrame() => Chapter11a.FillFrame(frame);

        [Benchmark]
        public void Chapter11b_FillFrame() => Chapter11b.FillFrame(frame);

        [Benchmark]
        public void Chapter11c_FillFrame() => Chapter11c.FillFrame(frame);
    }
}
