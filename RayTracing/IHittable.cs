namespace RayTracing {
    public interface IHittable {
        public bool Hit(in Ray ray, float minimum, float maximum, out HitRecord rec);
    }
}
