﻿using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RayTracing {
    public static class Chapter06b {
        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            var lowerLeftCorner = new Vector3(-2f, -1f, -1f);
            var horizontal = new Vector3(4f, 0, 0);
            var vertical = new Vector3(0, 2f, 0);
            var origin = Vector3.Zero;
            var spheres = new List<IEntity> {
                new Sphere(new Vector3(0, 0, -1), 0.5f),
                new Sphere(new Vector3(0, -100.5f, -1), 100),
            };
            var entities = new EntityList(spheres);
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var u = i / (float) width;
                    var v = j / (float) height;
                    var ray = new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical);
                    frame.AddColor(ComputeColor(ray, entities));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Color ComputeColor(in Ray ray, IEntity world) {
            Hit? hit;
            if((hit = world.Hit(ray, 0, float.MaxValue)) == null) {
                return new Color(Vector3.Lerp(Vector3.One, new Vector3(0.5f, 0.7f, 1), 0.5f * (Vector3.Normalize(ray.Direction).Y + 1)));
            }

            var normal = hit.Value.Normal;
            return new Color(0.5f * new Vector3(normal.X + 1, normal.Y + 1, normal.Z + 1));
        }
    }
}
