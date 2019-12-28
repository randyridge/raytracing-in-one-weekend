using System;
using System.Numerics;

namespace RayTracing {
    public sealed class Camera3 {
        public Camera3(Vector3 lookFrom, Vector3 lookAt, Vector3 up, float verticalFieldOfView, float aspectRatio) {
            var theta = verticalFieldOfView * (float) Math.PI / 180;
            var halfHeight = (float) Math.Tan(theta / 2);
            var halfWidth = aspectRatio * halfHeight;
            var w = Vector3.Normalize(lookFrom - lookAt);
            var u = Vector3.Normalize(Vector3.Cross(up, w));
            var v = Vector3.Cross(w, u);
            Origin = lookFrom;
            Horizontal = 2 * halfWidth * u;
            LowerLeftCorner = Origin - halfWidth * u - halfHeight * v - w;
            Vertical = 2 * halfHeight * v;
        }

        public Vector3 Horizontal { get; }

        public Vector3 LowerLeftCorner { get; }

        public Vector3 Origin { get; }

        public Vector3 Vertical { get; }

        public Ray GetRay(float u, float v) => new Ray(Origin, LowerLeftCorner + u * Horizontal + v * Vertical - Origin);
    }
}
