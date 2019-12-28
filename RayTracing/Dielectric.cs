using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct Dielectric : IMaterial {
        public Dielectric(float refractiveIndex) {
            RefractiveIndex = refractiveIndex;
        }

        public float RefractiveIndex { get; }

        public bool Scatter(in Ray incoming, in HitRecord rec, out Vector3 attenuation, out Ray scattered) {
            attenuation = Vector3.One;

            Vector3 outwardNormal;
            float niOverNt;

            if(Vector3.Dot(incoming.Direction, rec.Normal) > 0) {
                outwardNormal = -rec.Normal;
                niOverNt = RefractiveIndex;
            }
            else {
                outwardNormal = rec.Normal;
                niOverNt = 1.0f / RefractiveIndex;
            }

            if(Refract(incoming.Direction, outwardNormal, niOverNt, out var refracted)) {
                scattered = new Ray(rec.Position, refracted);
            }
            else {
                scattered = new Ray(rec.Position, Reflect(incoming.Direction, rec.Normal));
                return false;
            }

            return true;
        }

        private static Vector3 Reflect(Vector3 v, Vector3 n) => v - 2 * Vector3.Dot(v, n) * n;

        private static bool Refract(in Vector3 v, in Vector3 n, float niOverNt, out Vector3 refracted) {
            refracted = new Vector3();
            var uv = Vector3.Normalize(v);
            var dt = Vector3.Dot(uv, n);
            var discriminant = 1.0f - niOverNt * niOverNt * (1 - dt * dt);
            if(discriminant > 0) {
                refracted = niOverNt * (uv - n * dt) - n * (float) Math.Sqrt(discriminant);
                return true;
            }

            return false;
        }
    }
}
