using System.Numerics;

namespace RayTracing {
    public interface IMaterial {
        public bool Scatter(in Ray incoming, in HitRecord hitRecord, out Vector3 attenuation, out Ray scattered);
    }
}
