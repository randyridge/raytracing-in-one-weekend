using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing {
    public static class Chapter07 {
        private const int NumberOfSamples = 100;
        private static readonly Camera Camera = new Camera();
        private static readonly EntityList Entities = new EntityList(new List<IEntity> {
            new Sphere(new Vector3(0, 0, -1), 0.5f),
            new Sphere(new Vector3(0, -100.5f, -1), 100)
        });

        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var colorVector = Vector3.Zero;
                    for(var sample = 0; sample < NumberOfSamples; sample++) {
                        var u = (float) ((i + Random.NextDouble) / width);
                        var v = (float) ((j + Random.NextDouble) / height);
                        var ray = Camera.GetRay(u, v);
                        colorVector += ComputeColor(ray, Entities);
                    }

                    colorVector /= NumberOfSamples;
                    frame.AddColor(new Color(colorVector));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 ComputeColor(in Ray ray, IEntity world) {
            Hit? hit;
            if((hit = world.Hit(ray, 0, float.MaxValue)) == null) {
                return Vector3.Lerp(Vector3.One, new Vector3(0.5f, 0.7f, 1), 0.5f * (Vector3.Normalize(ray.Direction).Y + 1));
            }

            var normal = hit.Value.Normal;
            return 0.5f * new Vector3(normal.X + 1, normal.Y + 1, normal.Z + 1);
        }
    }
}
