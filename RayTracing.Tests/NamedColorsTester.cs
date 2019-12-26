using Shouldly;
using Xunit;

namespace RayTracing {
    public static class NamedColorsTester {
        public static class Black {
            [Fact]
            public static void returns_correct_values() => VerifyColor(NamedColors.Black, 0, 0, 0);
        }

        public static class Blue {
            [Fact]
            public static void returns_correct_values() => VerifyColor(NamedColors.Blue, 0, 0, 255);
        }

        public static class Green {
            [Fact]
            public static void returns_correct_values() => VerifyColor(NamedColors.Green, 0, 255, 0);
        }

        public static class Red {
            [Fact]
            public static void returns_correct_values() => VerifyColor(NamedColors.Red, 255, 0, 0);
        }

        public static class White {
            [Fact]
            public static void returns_correct_values() => VerifyColor(NamedColors.White, 255, 255, 255);
        }

        public static class Yellow {
            [Fact]
            public static void returns_correct_values() => VerifyColor(NamedColors.Yellow, 255, 255, 0);
        }

        private static void VerifyColor(Color color, int red, int green, int blue) {
            color.Red.ShouldBe((byte) red);
            color.Green.ShouldBe((byte) green);
            color.Blue.ShouldBe((byte) blue);
        }
    }
}
