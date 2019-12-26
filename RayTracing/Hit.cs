using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct Hit : IEquatable<Hit> {
        public Hit(float t, Vector3 position, Vector3 normal) {
            T = t;
            Position = position;
            Normal = normal;
        }

        public Vector3 Normal { get; }

        public Vector3 Position { get; }

        public float T { get; }

        public bool Equals(Hit other) => T.Equals(other.T) && Position.Equals(other.Position) && Normal.Equals(other.Normal);

        public static bool operator ==(Hit left, Hit right) => left.Equals(right);

        public static bool operator !=(Hit left, Hit right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Hit other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(T, Position, Normal);
    }
}
