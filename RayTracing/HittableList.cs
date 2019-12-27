using System.Collections.Generic;
using RandyRidge.Common;

namespace RayTracing {
    public sealed class HittableList : IHittable {
        private readonly List<IHittable> hittables;

        public HittableList(List<IHittable> hittables) {
            this.hittables = Guard.NotNull(hittables, nameof(hittables));
        }

        public bool Hit(in Ray ray, float minimum, float maximum, out HitRecord rec) {
            rec = new HitRecord();
            var isHit = false;
            var closestSoFar = maximum;
            for(var i = 0; i < hittables.Count; i++) {
                if(hittables[i].Hit(ray, minimum, closestSoFar, out var temp)) {
                    isHit = true;
                    closestSoFar = temp.Time;
                    rec = temp;
                }
            }

            return isHit;
        }
    }
}
