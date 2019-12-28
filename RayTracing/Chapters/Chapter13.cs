using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing.Chapters {
    public static class Chapter13 {
        private const int MaxDepth = 50;
        private const int NumberOfSamples = 10;
        private static readonly HittableList Hittables = BuildRandomScene();

        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            var lookFrom = new Vector3(13, 2, 3);
            var lookAt = new Vector3(0, 0, 0);
            var distanceToFocus = 10;
            var aperture = 0.1f;
            var camera = new Camera4(lookFrom, lookAt, new Vector3(0, 1, 0), 20, width / (float) height, aperture, distanceToFocus);
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var colorVector = Vector3.Zero;
                    for(var sample = 0; sample < NumberOfSamples; sample++) {
                        var u = (float) ((i + Random.NextDouble) / width);
                        var v = (float) ((j + Random.NextDouble) / height);
                        var ray = camera.GetRay(u, v);
                        colorVector += ComputeColor(ray, Hittables, 0);
                    }

                    colorVector /= NumberOfSamples;
                    colorVector = new Vector3((float) Math.Sqrt(colorVector.X), (float) Math.Sqrt(colorVector.Y), (float) Math.Sqrt(colorVector.Z));
                    frame.AddColor(new Color(colorVector));
                }
            }
        }

        private static HittableList BuildRandomScene() {
            const int NumberOfSpheres = 500;
            var list = new List<IHittable>(NumberOfSpheres + 1) {
                new Sphere(new Vector3(0, -1000, 0), 1000, new Lambertian(new Vector3(0.5f, 0.5f, 0.5f)))
            };
            for(var a = -11; a < 11; a++) {
                for(var b = -11; b < 11; b++) {
                    var chooseMaterial = (float) Random.NextDouble;
                    var center = new Vector3(a + 0.9f * (float) Random.NextDouble, 0.2f, b + 0.9f * (float) Random.NextDouble);
                    if((center - new Vector3(4, 0.2f, 0)).Length() > 0.9f) {
                        if(chooseMaterial < 0.8f) {
                            // diffuse
                            list.Add(new Sphere(center, 0.2f,
                                new Lambertian(new Vector3((float) Random.NextDouble * (float) Random.NextDouble,
                                    (float) Random.NextDouble * (float) Random.NextDouble,
                                    (float) Random.NextDouble * (float) Random.NextDouble)
                                )
                            ));
                        }
                        else if(chooseMaterial < 0.95f) {
                            // metal
                            list.Add(new Sphere(center, 0.2f,
                                new Metal(new Vector3(0.5f * (1 + (float) Random.NextDouble),
                                        0.5f * (1 + (float) Random.NextDouble),
                                        0.5f * (1 + (float) Random.NextDouble)),
                                    0.5f * (float) Random.NextDouble)
                                ));
                        }
                        else {
                            // glass
                            list.Add(new Sphere(center, 0.2f, new Glass(1.5f)));
                        }
                    }
                }
            }

            list.Add(new Sphere(new Vector3(0, 1, 0), 1.0f, new Glass(1.5f)));
            list.Add(new Sphere(new Vector3(-4, 1, 0), 1.0f, new Lambertian(new Vector3(0.4f, 0.2f, 0.1f))));
            list.Add(new Sphere(new Vector3(4, 1, 0), 1.0f, new Metal(new Vector3(0.7f, 0.6f, 0.5f), 0.0f)));

            return new HittableList(list);
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
