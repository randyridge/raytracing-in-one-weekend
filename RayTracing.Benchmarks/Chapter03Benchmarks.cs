using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class Chapter03Benchmarks {
        [Benchmark]
        public List<Color> Run() => Chapter03.Run(200, 100);
    }
}
