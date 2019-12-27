using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct Lambertian : IMaterial, IEquatable<Lambertian> {
        public Lambertian(Vector3 albedo) {
            Albedo = albedo;
        }

        public Vector3 Albedo { get; }

        public bool Equals(Lambertian other) => Albedo.Equals(other.Albedo);

        public bool Scatter(in Ray incoming, in Hit hit, out Vector3 attenuation, out Ray scattered) {
            var target = hit.Position + hit.Normal + Random.InUnitSphere();
            attenuation = Albedo;
            scattered = new Ray(hit.Position, target - hit.Position);
            return true;
        }

        public static bool operator ==(Lambertian left, Lambertian right) => left.Equals(right);

        public static bool operator !=(Lambertian left, Lambertian right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Lambertian other && Equals(other);

        public override int GetHashCode() => Albedo.GetHashCode();
    }
}
