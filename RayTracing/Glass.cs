using System;
using System.Numerics;

namespace RayTracing {
    public readonly struct Glass : IMaterial {
        public Glass(float refractiveIndex) {
            RefractiveIndex = refractiveIndex;
        }

        public float RefractiveIndex { get; }

        public bool Scatter(in Ray incoming, in HitRecord rec, out Vector3 attenuation, out Ray scattered) {
            attenuation = Vector3.One;

            Vector3 outwardNormal;
            float niOverNt;
            float cosine;

            if(Vector3.Dot(incoming.Direction, rec.Normal) > 0) {
                outwardNormal = -rec.Normal;
                niOverNt = RefractiveIndex;
                cosine = RefractiveIndex * Vector3.Dot(incoming.Direction, rec.Normal) / incoming.Direction.Length();
            }
            else {
                outwardNormal = rec.Normal;
                niOverNt = 1.0f / RefractiveIndex;
                cosine = -Vector3.Dot(incoming.Direction, rec.Normal) / incoming.Direction.Length();
            }

            var reflectionProbability = Refract(incoming.Direction, outwardNormal, niOverNt, out var refracted) ? Schlick(cosine, RefractiveIndex) : 1.0f;
            scattered = Random.NextDouble < reflectionProbability ? new Ray(rec.Position, Reflect(incoming.Direction, rec.Normal)) : new Ray(rec.Position, refracted);
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

        private static float Schlick(float cosine, float refractiveIndex) {
            var r0 = (1 - refractiveIndex) / (1 + refractiveIndex);
            r0 *= r0;
            return r0 + (1 - r0) * (float) Math.Pow(1 - cosine, 5);
        }
    }
}
