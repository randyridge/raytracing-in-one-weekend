using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class Chapter04Benchmarks {
        private readonly Frame frame = new Frame(200, 100);

        [Benchmark]
        public void Chapter04_FillFrame() => Chapter04.FillFrame(frame);
    }
}
