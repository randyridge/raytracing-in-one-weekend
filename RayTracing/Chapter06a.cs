using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing {
    public static class Chapter06a {
        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            var lowerLeftCorner = new Vector3(-2f, -1f, -1f);
            var horizontal = new Vector3(4f, 0, 0);
            var vertical = new Vector3(0, 2f, 0);
            var origin = Vector3.Zero;
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var u = i / (float) width;
                    var v = j / (float) height;
                    frame.AddColor(ComputeColor(new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical)));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Color ComputeColor(in Ray ray) {
            var t = IsSphereHit(new Vector3(0, 0, -1), 0.5f, ray);
            if(t > 0) {
                var n = Vector3.Normalize(ray.PointAt(t)) - new Vector3(0, 0, -1);
                return new Color(0.5f * new Vector3(n.X + 1, n.Y + 1, n.Z + 1));
            }
            return new Color(Vector3.Lerp(Vector3.One, new Vector3(0.5f, 0.7f, 1.0f), 0.5f * (Vector3.Normalize(ray.Direction).Y + 1)));
        }

        private static float IsSphereHit(in Vector3 center, float radius, in Ray ray) {
            var oc = ray.Origin - center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2.0f * Vector3.Dot(oc, ray.Direction);
            var c = Vector3.Dot(oc, oc) - radius * radius;
            var discriminant = b * b - 4 * a * c;
            return discriminant < 0 ? -1 : (-b - (float) Math.Sqrt(discriminant)) / (2.0f * a);
        }
    }
}
