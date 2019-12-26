namespace RayTracing {
    public interface IEntity {
        public Hit? Hit(in Ray ray, float minimum, float maximum);
    }
}
