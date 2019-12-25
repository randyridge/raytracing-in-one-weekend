using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class Chapter02Benchmarks {
        private readonly Frame frame = new Frame(200, 100);

        [Benchmark]
        public void Chapter02_FillFrame() => Chapter02.FillFrame(frame);
    }
}
