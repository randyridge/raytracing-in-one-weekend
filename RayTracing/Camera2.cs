using System;
using System.Numerics;

namespace RayTracing {
    public sealed class Camera2 {
        public Camera2(float verticalFieldOfView, float aspectRatio) {
            var theta = verticalFieldOfView * (float) Math.PI / 180;
            var halfHeight = (float) Math.Tan(theta / 2);
            var halfWidth = aspectRatio * halfHeight;
            Horizontal = new Vector3(2 * halfWidth, 0, 0);
            LowerLeftCorner = new Vector3(-halfWidth, -halfHeight, -1);
            Origin = Vector3.Zero;
            Vertical = new Vector3(0, 2 * halfHeight, 0);
        }

        public Vector3 Horizontal { get; }

        public Vector3 LowerLeftCorner { get; }

        public Vector3 Origin { get; }

        public Vector3 Vertical { get; }

        public Ray GetRay(float u, float v) => new Ray(Origin, LowerLeftCorner + u * Horizontal + v * Vertical - Origin);
    }
}
