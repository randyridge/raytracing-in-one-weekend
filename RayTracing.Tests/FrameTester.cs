using System;
using Shouldly;
using Xunit;

namespace RayTracing {
    public abstract class FrameTester {
        private readonly Frame frame = new Frame(200, 100);

        public sealed class Constructor : FrameTester {
            [Fact]
            public void sets_height() => frame.Height.ShouldBe(100);

            [Fact]
            public void sets_width() => frame.Width.ShouldBe(200);

            [Fact]
            public void throws_on_negative_height() => Should.Throw<ArgumentOutOfRangeException>(() => new Frame(42, -1));

            [Fact]
            public void throws_on_negative_width() => Should.Throw<ArgumentOutOfRangeException>(() => new Frame(-1, 42));
        }
    }
}
