using System.IO;
using Shouldly;
using Xunit;

namespace RayTracing {
    public abstract class PpmReaderTester {
        public sealed class Read {
            [Fact]
            public void reads_frame() {
                using var fileStream = new FileStream(Common.GetInputFilePath("pattern.ppm"), FileMode.Open, FileAccess.Read);
                var frame = PpmReader.Read(fileStream);
                frame.ShouldNotBeNull();
                frame.Width.ShouldBe(3);
                frame.Height.ShouldBe(2);
                frame.Colors.Count.ShouldBeGreaterThan(0);

                frame.Colors[0].ShouldBe(NamedColors.Red);
                frame.Colors[1].ShouldBe(NamedColors.Green);
                frame.Colors[2].ShouldBe(NamedColors.Blue);

                frame.Colors[3].ShouldBe(NamedColors.Yellow);
                frame.Colors[4].ShouldBe(NamedColors.White);
                frame.Colors[5].ShouldBe(NamedColors.Black);
            }
        }
    }
}
