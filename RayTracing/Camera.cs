using System.Numerics;

namespace RayTracing {
    public sealed class Camera {
        public Camera() {
            Horizontal = new Vector3(4, 0, 0);
            LowerLeftCorner = new Vector3(-2, -1, -1);
            Origin = Vector3.Zero;
            Vertical = new Vector3(0, 2, 0);
        }

        public Vector3 Horizontal { get; }

        public Vector3 LowerLeftCorner { get; }

        public Vector3 Origin { get; }

        public Vector3 Vertical { get; }

        public Ray GetRay(float u, float v) => new Ray(Origin, LowerLeftCorner + u * Horizontal + v * Vertical - Origin);
    }
}
