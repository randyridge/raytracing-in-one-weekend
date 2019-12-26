using Shouldly;
using Xunit;

// ReSharper disable EqualExpressionComparison

namespace RayTracing {
    public abstract class ColorTester {
        public sealed class ClampChannel {
            [Fact]
            public void clamps_to_255() => Color.ClampChannel(2f).ShouldBe((byte) 255);

            [Fact]
            public void clamps_to_zero() => Color.ClampChannel(-1f).ShouldBe((byte) 0);

            [Fact]
            public void scales_inside_range() => Color.ClampChannel(0.5f).ShouldBe((byte) 128);
        }

        public sealed class Constructor : ColorTester {
            [Fact]
            public void sets_blue() => NamedColors.Blue.Blue.ShouldBe((byte) 255);

            [Fact]
            public void sets_green() => NamedColors.Green.Green.ShouldBe((byte) 255);

            [Fact]
            public void sets_red() => NamedColors.Red.Red.ShouldBe((byte) 255);
        }

        public sealed class ConstructorFloats {
            [Fact]
            public void sets_blue() => new Color(0f, 0f, 1f).ShouldBe(NamedColors.Blue);

            [Fact]
            public void sets_green() => new Color(0f, 1f, 0f).ShouldBe(NamedColors.Green);

            [Fact]
            public void sets_red() => new Color(1f, 0f, 0f).ShouldBe(NamedColors.Red);
        }

        public sealed class Equality : ColorTester {
            [Fact]
            public void returns_false_on_inequality() {
                (NamedColors.Red == NamedColors.Green).ShouldBeFalse();
                (NamedColors.Red == NamedColors.Blue).ShouldBeFalse();
            }

            [Fact]
            public void returns_true_on_equality() {
                (NamedColors.Red == NamedColors.Red).ShouldBeTrue();
                (NamedColors.Green == NamedColors.Green).ShouldBeTrue();
                (NamedColors.Blue == NamedColors.Blue).ShouldBeTrue();
            }
        }

        public sealed class EqualsTests : ColorTester {
            [Fact]
            // ReSharper disable once SuspiciousTypeConversion.Global
            public void returns_false_on_different_type() => NamedColors.Red.Equals("Red").ShouldBeFalse();

            [Fact]
            public void returns_false_on_inequality() {
                NamedColors.Red.Equals(NamedColors.Green).ShouldBeFalse();
                NamedColors.Red.Equals(NamedColors.Blue).ShouldBeFalse();
            }

            [Fact]
            public void returns_true_on_equality() {
                NamedColors.Red.Equals(NamedColors.Red).ShouldBeTrue();
                NamedColors.Green.Equals(NamedColors.Green).ShouldBeTrue();
                NamedColors.Blue.Equals(NamedColors.Blue).ShouldBeTrue();
            }
        }

        public sealed class GetHashCodeTests : ColorTester {
            [Fact]
            public void returns_hash_code() => NamedColors.Red.GetHashCode().ShouldBeOfType<int>();
        }

        public sealed class Inequality : ColorTester {
            [Fact]
            public void returns_false_on_equality() {
                (NamedColors.Red != NamedColors.Red).ShouldBeFalse();
                (NamedColors.Green != NamedColors.Green).ShouldBeFalse();
                (NamedColors.Blue != NamedColors.Blue).ShouldBeFalse();
            }

            [Fact]
            public void returns_true_on_inequality() {
                (NamedColors.Red != NamedColors.Green).ShouldBeTrue();
                (NamedColors.Red != NamedColors.Blue).ShouldBeTrue();
            }
        }
    }
}
