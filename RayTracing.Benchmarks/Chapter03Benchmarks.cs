using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class Chapter03Benchmarks {
        private readonly Frame frame = new Frame(200, 100);

        [Benchmark]
        public void Chapter03_FillFrame() => Chapter03.FillFrame(frame);
    }
}
