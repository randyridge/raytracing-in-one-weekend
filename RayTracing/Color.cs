using System;

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

        public static bool operator ==(Color left, Color right) => left.Equals(right);

        public static bool operator !=(Color left, Color right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Color other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Red, Green, Blue);
    }
}
