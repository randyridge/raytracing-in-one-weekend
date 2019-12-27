using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing.Chapters {
    public static class Chapter04 {
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
                    var color = ComputeColor(new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical));
                    frame.AddColor(new Color(color.X, color.Y, color.Z));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 ComputeColor(in Ray ray) => Vector3.Lerp(Vector3.One, new Vector3(0.5f, 0.7f, 1.0f), 0.5f * (Vector3.Normalize(ray.Direction).Y + 1.0f));
    }
}
