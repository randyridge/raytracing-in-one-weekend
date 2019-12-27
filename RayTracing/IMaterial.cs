using System.Numerics;

namespace RayTracing {
    public interface IMaterial {
        public bool Scatter(in Ray incoming, in Hit hit, out Vector3 attenuation, out Ray scattered);
    }
}
