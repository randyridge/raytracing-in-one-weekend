﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing {
    public static class Chapter08b {
        private const int MaxDepth = 50;
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
                        colorVector += ComputeColor(ray, Entities, MaxDepth);
                    }

                    colorVector /= NumberOfSamples;
                    colorVector = new Vector3((float) Math.Sqrt(colorVector.X), (float) Math.Sqrt(colorVector.Y), (float) Math.Sqrt(colorVector.Z));
                    frame.AddColor(new Color(colorVector));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 ComputeColor(in Ray ray, IEntity world, int depth) {
            if(depth <= 0) {
                return Vector3.Zero;
            }

            Hit? hit;
            if((hit = world.Hit(ray, 0.001f, float.MaxValue)) != null) {
                var rec = hit.Value;
                var target = rec.Position + rec.Normal + Random.InUnitSphere();
                return 0.5f * ComputeColor(new Ray(rec.Position, target - rec.Position), world, depth - 1);
            }

            var unitDirection = Vector3.Normalize(ray.Direction);
            var t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * Vector3.One + t * new Vector3(0.5f, 0.7f, 1.0f);
        }
    }
}
