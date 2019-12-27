using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct Metal : IMaterial, IEquatable<Metal> {
        public Metal(Vector3 albedo, float fuzziness) {
            Albedo = albedo;
            Fuzziness = fuzziness;
        }

        public Vector3 Albedo { get; }

        public float Fuzziness { get; }

        public bool Equals(Metal other) => Albedo.Equals(other.Albedo) && Fuzziness.Equals(other.Fuzziness);

        public bool Scatter(in Ray incoming, in HitRecord hitRecord, out Vector3 attenuation, out Ray scattered) {
            var reflected = Reflect(Vector3.Normalize(incoming.Direction), hitRecord.Normal);
            scattered = new Ray(hitRecord.Position, reflected + Fuzziness * Random.InUnitSphere());
            attenuation = Albedo;
            return Vector3.Dot(scattered.Direction, hitRecord.Normal) > 0;
        }

        public static bool operator ==(Metal left, Metal right) => left.Equals(right);

        public static bool operator !=(Metal left, Metal right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is Metal other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Albedo, Fuzziness);

        private static Vector3 Reflect(Vector3 v, Vector3 n) => v - 2 * Vector3.Dot(v, n) * n;
    }
}
