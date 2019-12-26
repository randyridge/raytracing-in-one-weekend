using System.IO;
using NetVips;
using SharpSharp;
using Shouldly;
using Xunit;

namespace RayTracing {
    public static class OutputTester {
        public sealed class Chapter02 {
            [Fact]
            public void chapter02_matches() {
                var expected = CalculateExpectedHash(Common.GetInputFilePath("img-1-02-2.jpg"));
                var actual = CalculateActualHash(Common.GetOutputFilePath("chapter02.ppm"));
                VerifyHammingDistance(expected, actual);
            }

            [Fact]
            public void chapter04_matches() {
                var expected = CalculateExpectedHash(Common.GetInputFilePath("img-1-04-1.jpg"));
                var actual = CalculateActualHash(Common.GetOutputFilePath("chapter04.ppm"));
                VerifyHammingDistance(expected, actual);
            }

            [Fact]
            public void chapter05_matches() {
                var expected = CalculateExpectedHash(Common.GetInputFilePath("img-1-05-1.jpg"));
                var actual = CalculateActualHash(Common.GetOutputFilePath("chapter05.ppm"));
                VerifyHammingDistance(expected, actual);
            }

            [Fact]
            public void chapter06a_matches() {
                var expected = CalculateExpectedHash(Common.GetInputFilePath("img-1-06-1.jpg"));
                var actual = CalculateActualHash(Common.GetOutputFilePath("chapter06a.ppm"));
                VerifyHammingDistance(expected, actual);
            }

            [Fact]
            public void chapter06b_matches() {
                var expected = CalculateExpectedHash(Common.GetInputFilePath("img-1-06-2.jpg"));
                var actual = CalculateActualHash(Common.GetOutputFilePath("chapter06b.ppm"));
                VerifyHammingDistance(expected, actual);
            }

            private static long CalculateActualHash(string fileName) {
                // TODO: ppm isn't included in windows libvips full, it looks like it needs to be configured to be built... :/
                //ImagePipeline.FromFile(Common.GetOutputFilePath("chapter02.ppm")).Webp(new WebpOptions(100, 100, true)).ToBuffer(out var actual);
                using var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var frame = PpmReader.Read(fileStream);
                var buffer = new byte[frame.Width * frame.Height * 3];
                var position = 0;
                foreach(var color in frame.Colors) {
                    buffer[position] = color.Red;
                    buffer[position + 1] = color.Green;
                    buffer[position + 2] = color.Blue;
                    position += 3;
                }

                using var image = Image.NewFromMemory(buffer, 200, 100, 3, "uchar");
                ImagePipeline.FromImage(image).Webp(new WebpOptions(100, 100, true)).ToBuffer(out var actual);
                return DifferenceHash.HashLong(actual);
            }

            private static long CalculateExpectedHash(string fileName) {
                ImagePipeline.FromFile(fileName).Webp(new WebpOptions(100, 100, true)).ToBuffer(out var expected);
                return DifferenceHash.HashLong(expected);
            }

            private static void VerifyHammingDistance(long expected, long actual) {
                var count = 0;
                for(var i = 0; i < 64; i++) {
                    if(((expected >> i) & 1) != ((actual >> i) & 1)) {
                        count++;
                    }
                }

                count.ShouldBeLessThan(10);
            }
        }
    }
}
