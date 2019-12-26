using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing {
    public readonly struct Color : IEquatable<Color> {
        public Color(byte red, byte green, byte blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Color(float red, float green, float blue) : this(ClampChannel(red), ClampChannel(green), ClampChannel(blue)) {
        }

        public Color(Vector3 vector3) : this(ClampChannel(vector3.X), ClampChannel(vector3.Y), ClampChannel(vector3.Z)) {
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
        public static Color operator +(Color left, Color right) => new Color(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color operator /(Color left, float scalar) => new Color(left.Red / scalar, left.Green / scalar, left.Blue / scalar);

        public static bool operator ==(Color left, Color right) => left.Equals(right);

        public static bool operator !=(Color left, Color right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Color other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Red, Green, Blue);
    }
}
