using System.IO;
using System.Numerics;
using System.Text;

namespace RayTracing {
    public static class Chapter03 {
        public static void Run(Stream stream, int nx, int ny) {
            using var sw = new StreamWriter(stream, Encoding.ASCII, -1, true);
            sw.Write($"P3\n {nx} {ny}\n255\n");
            for(var j = ny - 1; j >= 0; j--) {
                for(var i = 0; i < nx; i++) {
                    var col = new Vector3(i / (float) nx, j / (float) ny, 0.2f);
                    var ir = (int) (255.99f * col.X);
                    var ig = (int) (255.99f * col.Y);
                    var ib = (int) (255.99f * col.Z);
                    sw.Write($"{ir} {ig} {ib}\n");
                }
            }
        }
    }
}
