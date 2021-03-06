﻿using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct HitRecord : IEquatable<HitRecord> {
        public HitRecord(float time, Vector3 position, Vector3 normal, IMaterial material) {
            Time = time;
            Position = position;
            Normal = normal;
            Material = material;
        }

        public IMaterial Material { get; }

        public Vector3 Normal { get; }

        public Vector3 Position { get; }

        public float Time { get; }

        public bool Equals(HitRecord other) => Time.Equals(other.Time) && Position.Equals(other.Position) && Normal.Equals(other.Normal) && Material.Equals(other.Material);

        public static bool operator ==(HitRecord left, HitRecord right) => left.Equals(right);

        public static bool operator !=(HitRecord left, HitRecord right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is HitRecord other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Time, Position, Normal);
    }
}
