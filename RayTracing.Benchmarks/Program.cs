using System.Reflection;
using BenchmarkDotNet.Running;

namespace RayTracing {
    internal static class Program {
        private static void Main() {
            BenchmarkRunner.Run(Assembly.GetAssembly(typeof(Program)));
        }
    }
}
