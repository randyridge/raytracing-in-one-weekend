using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing.Chapters {
    public static class Chapter10b {
        private const int MaxDepth = 50;
        private const int NumberOfSamples = 100;
        private static readonly Camera Camera = new Camera();
        private static readonly HittableList Hittables = new HittableList(new List<IHittable> {
            new Sphere(new Vector3(0, 0, -1), 0.5f, new Lambertian(new Vector3(0.1f, 0.2f, 0.5f))),
            new Sphere(new Vector3(0, -100.5f, -1), 100, new Lambertian(new Vector3(0.8f, 0.8f, 0.0f))),
            new Sphere(new Vector3(1, 0, -1), 0.5f, new Metal(new Vector3(0.8f, 0.6f, 0.2f), 0.3f)),
            new Sphere(new Vector3(-1, 0, -1), 0.5f, new Glass(1.5f)),
            new Sphere(new Vector3(-1, 0, -1), -0.45f, new Glass(1.5f)),
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
                        colorVector += ComputeColor(ray, Hittables, 0);
                    }

                    colorVector /= NumberOfSamples;
                    colorVector = new Vector3((float) Math.Sqrt(colorVector.X), (float) Math.Sqrt(colorVector.Y), (float) Math.Sqrt(colorVector.Z));
                    frame.AddColor(new Color(colorVector));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 ComputeColor(in Ray ray, in IHittable world, int depth) {
            if(world.Hit(ray, 0.001f, float.MaxValue, out var rec)) {
                if(depth < MaxDepth && rec.Material.Scatter(ray, rec, out var attenuation, out var scattered)) {
                    return attenuation * ComputeColor(scattered, Hittables, depth + 1);
                }
                return Vector3.Zero;
            }

            var unitDirection = Vector3.Normalize(ray.Direction);
            var time = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - time) * Vector3.One + time * new Vector3(0.5f, 0.7f, 1.0f);
        }
    }
}
