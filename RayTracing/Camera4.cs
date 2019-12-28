using System;
using System.Numerics;

namespace RayTracing {
    public sealed class Camera4 {
        public Camera4(Vector3 lookFrom, Vector3 lookAt, Vector3 up, float verticalFieldOfView, float aspectRatio, float aperture, float focusDistance) {
            var theta = verticalFieldOfView * (float) Math.PI / 180;
            var halfHeight = (float) Math.Tan(theta / 2);
            var halfWidth = aspectRatio * halfHeight;
            W = Vector3.Normalize(lookFrom - lookAt);
            U = Vector3.Normalize(Vector3.Cross(up, W));
            V = Vector3.Cross(W, U);
            LensRadius = aperture / 2;
            Origin = lookFrom;
            Horizontal = 2 * halfWidth * focusDistance * U;
            LowerLeftCorner = Origin
                              - halfWidth * focusDistance * U
                              - halfHeight * focusDistance * V
                              - focusDistance * W;
            Vertical = 2 * halfHeight * focusDistance * V;
        }

        public Vector3 Horizontal { get; }

        public float LensRadius { get; }

        public Vector3 LowerLeftCorner { get; }

        public Vector3 Origin { get; }

        public Vector3 U { get; }

        public Vector3 V { get; }

        public Vector3 Vertical { get; }

        public Vector3 W { get; }

        public Ray GetRay(float s, float t) {
            var rd = LensRadius * Random.InUnitSphere();
            var offset = U * rd.X + V * rd.Y;
            return new Ray(Origin + offset, LowerLeftCorner + s * Horizontal + t * Vertical - Origin - offset);
        }
    }
}
