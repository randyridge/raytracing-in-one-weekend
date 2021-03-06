﻿using System.IO;
using SharpSharp;
using Shouldly;
using Xunit;

namespace RayTracing {
    public static class OutputTester {
        public sealed class Chapter02 {
            [Fact]
            public void chapter02_matches() => CompareImages("img-1-02-2.jpg", "chapter02.ppm");

            [Fact]
            public void chapter04_matches() => CompareImages("img-1-04-1.jpg", "chapter04.ppm");

            [Fact]
            public void chapter05_matches() => CompareImages("img-1-05-1.jpg", "chapter05.ppm");

            [Fact]
            public void chapter06a_matches() => CompareImages("img-1-06-1.jpg", "chapter06a.ppm");

            [Fact]
            public void chapter06b_matches() => CompareImages("img-1-06-2.jpg", "chapter06b.ppm");

            [Fact] // Chapter 07's image is a crop, so just use chapter 06's image.
            public void chapter07_matches() => CompareImages("img-1-06-2.jpg", "chapter07.ppm");

            [Fact]
            public void chapter08a_matches() => CompareImages("img-1-08-1.jpg", "chapter08a.ppm");

            [Fact]
            public void chapter08b_matches() => CompareImages("img-1-08-2.jpg", "chapter08b.ppm");

            [Fact]
            public void chapter09a_matches() => CompareImages("img-1-09-2.jpg", "chapter09a.ppm");

            [Fact]
            public void chapter09b_matches() => CompareImages("img-1-09-2.jpg", "chapter09b.ppm");

            [Fact]
            public void chapter10a_matches() => CompareImages("img-1-10-2.jpg", "chapter10a.ppm");

            [Fact]
            public void chapter10b_matches() => CompareImages("img-1-10-3.jpg", "chapter10b.ppm");

            [Fact]
            public void chapter11a_matches() => CompareImages("img-1-11-1.jpg", "chapter11a.ppm");

            [Fact]
            public void chapter11b_matches() => CompareImages("img-1-11-2.jpg", "chapter11b.ppm");

            [Fact]
            public void chapter11c_matches() => CompareImages("img-1-11-3.jpg", "chapter11c.ppm");

            [Fact]
            public void chapter12_matches() => CompareImages("img-1-12-1.jpg", "chapter12.ppm");

            [Fact(Skip = "random")]
            public void chapter13_matches() => CompareImages("img-1-13-1.jpg", "chapter13.ppm");

            private static long CalculateActualHash(string fileName) {
                using var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using var image = PpmReader.ImageFromPpm(fileStream);
                ImagePipeline.FromImage(image).Webp(new WebpOptions(100, 100, true)).ToBuffer(out var actual);
                return DifferenceHash.HashLong(actual);
            }

            private static long CalculateExpectedHash(string fileName) {
                ImagePipeline.FromFile(fileName).Webp(new WebpOptions(100, 100, true)).ToBuffer(out var expected);
                return DifferenceHash.HashLong(expected);
            }

            private static void CompareImages(string expectedPath, string actualPath) {
                var expected = CalculateExpectedHash(Common.GetInputFilePath(expectedPath));
                var actual = CalculateActualHash(Common.GetOutputFilePath(actualPath));
                VerifyHammingDistance(expected, actual);
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
