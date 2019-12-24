using System.IO;
using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class Chapter02Benchmark {
        [Benchmark(Baseline = true)]
        public void Chapter02Baseline() {
            using var ms = new MemoryStream();
            Chapter02.Run(ms, 200, 100);
        }

        [Benchmark]
        public void Chapter03Comparison() {
            using var ms = new MemoryStream();
            Chapter03.Run(ms, 200, 100);
        }
    }
}
