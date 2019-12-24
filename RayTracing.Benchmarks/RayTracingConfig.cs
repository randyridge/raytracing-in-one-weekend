using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace SharpSharp.Benchmarks {
    public sealed class RayTracingConfig : ManualConfig {
        public RayTracingConfig() {
            Add(MemoryDiagnoser.Default);

#if Windows
            Add(new NativeMemoryProfiler());
#endif

            Add(StatisticColumn.AllStatistics);

            Add(Job.Default
                .With(CoreRuntime.Core31)
                .With(Jit.RyuJit)
            );
        }
    }
}
