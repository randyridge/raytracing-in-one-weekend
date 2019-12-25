using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class PpmWriterBenchmarks : IDisposable {
        private const int Height = 100;
        private const int Width = 200;
        private readonly Frame frame;
        private readonly MemoryStream memoryStream;

        public PpmWriterBenchmarks() {
            frame = BuildFrame();
            memoryStream = new MemoryStream();
        }

        public void Dispose() {
            memoryStream.Dispose();
        }

        [Benchmark]
        public void PpmWriter_Write() => PpmWriter.Write(memoryStream, frame);

        private static Frame BuildFrame() {
            var frame = new Frame(Width, Height);
            Span<byte> bytes = new byte[Width * Height * 3];
            var random = new Random();
            random.NextBytes(bytes);
            var b = 0;
            for(var i = 0; i < Width * Height; i++) {
                frame.AddColor(new Color(bytes[b], bytes[b + 1], bytes[b + 2]));
                b += 3;
            }

            return frame;
        }
    }
}
