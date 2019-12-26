using System;
using System.Numerics;

namespace RayTracing {
    public sealed class Sphere : IEntity {
        public Sphere(Vector3 center, float radius) {
            Center = center;
            Radius = radius;
        }

        public Vector3 Center { get; }

        public float Radius { get; }

        public Hit? Hit(in Ray ray, float minimum, float maximum) {
            var oc = ray.Origin - Center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = Vector3.Dot(oc, ray.Direction);
            var c = Vector3.Dot(oc, oc) - Radius * Radius;
            var discriminant = b * b - a * c;
            if(discriminant < 0) {
                return null;
            }

            var temp = (-b - (float) Math.Sqrt(discriminant)) / a;
            var pointAt = ray.PointAt(temp);
            if(temp < maximum && temp > minimum) {
                return new Hit(temp, pointAt, (pointAt - Center) / Radius);
            }

            temp = (-b + (float) Math.Sqrt(discriminant)) / a;
            if(temp < maximum && temp > minimum) {
                return new Hit(temp, pointAt, (pointAt - Center) / Radius);
            }

            return null;
        }
    }
}
