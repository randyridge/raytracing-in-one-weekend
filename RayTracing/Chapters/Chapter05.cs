using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing.Chapters {
    public static class Chapter05 {
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
        private static Color ComputeColor(in Ray ray) => IsSphereHit(new Vector3(0, 0, -1), 0.5f, ray) ? NamedColors.Red : new Color(Vector3.Lerp(Vector3.One, new Vector3(0.5f, 0.7f, 1.0f), 0.5f * (Vector3.Normalize(ray.Direction).Y + 1.0f)));

        private static bool IsSphereHit(in Vector3 center, float radius, in Ray ray) {
            var oc = ray.Origin - center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2.0f * Vector3.Dot(oc, ray.Direction);
            var c = Vector3.Dot(oc, oc) - radius * radius;
            var discriminant = b * b - 4 * a * c;
            return discriminant > 0;
        }
    }
}
