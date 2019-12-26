using System;
using System.Runtime.CompilerServices;

namespace RayTracing {
    public readonly struct Color : IEquatable<Color> {
        public Color(byte red, byte green, byte blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Blue { get; }

        public byte Green { get; }

        public byte Red { get; }

        public bool Equals(Color other) => Red == other.Red && Green == other.Green && Blue == other.Blue;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ClampChannel(float channel) =>
            channel <= 0.0f ? (byte) 0
            : channel >= 1.0f ? (byte) 255
            : Math.Min((byte) (256.0f * channel), (byte) 255);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color FromNormalizedFloats(float red, float green, float blue) => new Color(ClampChannel(red), ClampChannel(green), ClampChannel(blue));

        public static bool operator ==(Color left, Color right) => left.Equals(right);

        public static bool operator !=(Color left, Color right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Color other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Red, Green, Blue);
    }
}
