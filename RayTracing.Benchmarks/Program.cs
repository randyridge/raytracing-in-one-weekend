using BenchmarkDotNet.Running;

namespace RayTracing {
    internal static class Program {
        private static void Main() {
            BenchmarkRunner.Run<Chapter02Benchmark>();
        }
    }
}
