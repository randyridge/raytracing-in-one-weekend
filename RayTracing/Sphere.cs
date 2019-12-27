using System;
using System.Numerics;

namespace RayTracing {
    public sealed class Sphere : IHittable {
        public Sphere(Vector3 center, float radius, IMaterial material) {
            Center = center;
            Radius = radius;
            Material = material;
        }

        public Vector3 Center { get; }

        public IMaterial Material { get; }

        public float Radius { get; }

        public bool Hit(in Ray ray, float minimum, float maximum, out HitRecord rec) {
            rec = new HitRecord();
            var oc = ray.Origin - Center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = Vector3.Dot(oc, ray.Direction);
            var c = Vector3.Dot(oc, oc) - Radius * Radius;
            var discriminant = b * b - a * c;
            if(discriminant > 0) {
                var time = (-b - (float) Math.Sqrt(discriminant)) / a;
                if(time < maximum && time > minimum) {
                    var pointAt = ray.PointAt(time);
                    rec = new HitRecord(time, pointAt, (pointAt - Center) / Radius, Material);
                    return true;
                }

                time = (-b + (float) Math.Sqrt(discriminant)) / a;

                if(time < maximum && time > minimum) {
                    var pointAt = ray.PointAt(time);
                    rec = new HitRecord(time, pointAt, (pointAt - Center) / Radius, Material);
                    return true;
                }
            }

            return false;
        }
    }
}
