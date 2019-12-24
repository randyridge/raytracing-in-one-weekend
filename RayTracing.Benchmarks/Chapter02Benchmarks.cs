using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class Chapter02Benchmarks {
        [Benchmark]
        public List<Color> Run() => Chapter02.Run(200, 100);
    }
}
