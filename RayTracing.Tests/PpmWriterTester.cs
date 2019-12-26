using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Shouldly;
using Xunit;

namespace RayTracing {
    [SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pending>")]
    public abstract class PpmWriterTester {
        private readonly Frame frame;
        private readonly MemoryStream memoryStream;

        protected PpmWriterTester() {
            frame = Common.BuildTestFrame();
            memoryStream = new MemoryStream();
        }

        public sealed class Write : PpmWriterTester {
            [Fact]
            public void writes_correct_values() {
                PpmWriter.Write(memoryStream, frame);
                memoryStream.Position = 0;
                var text = Encoding.ASCII.GetString(memoryStream.ToArray());
                text.ShouldBe(File.ReadAllText(Common.GetInputFilePath("pattern.ppm")));
            }
        }
    }
}
