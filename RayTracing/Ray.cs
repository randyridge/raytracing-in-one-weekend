using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct Ray : IEquatable<Ray> {
        public Ray(Vector3 origin, Vector3 direction) {
            Origin = origin;
            Direction = direction;
        }

        public Vector3 Direction { get; }

        public Vector3 Origin { get; }

        public bool Equals(Ray other) => Direction.Equals(other.Direction) && Origin.Equals(other.Origin);

        public static bool operator ==(Ray left, Ray right) => left.Equals(right);

        public static bool operator !=(Ray left, Ray right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Ray other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Direction, Origin);

        public Vector3 PointAt(float t) => Origin + t * Direction;
    }
}
