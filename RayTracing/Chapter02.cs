using System.IO;
using System.Text;

namespace RayTracing {
    public static class Chapter02 {
        public static void Run(Stream stream, int nx, int ny) {
            using var sw = new StreamWriter(stream, Encoding.ASCII, -1, true);
            sw.Write($"P3\n {nx} {ny}\n255\n");
            for(var j = ny - 1; j >= 0; j--) {
                for(var i = 0; i < nx; i++) {
                    var r = i / (float) nx;
                    var g = j / (float) ny;
                    var b = 0.2f;
                    var ir = (int) (255.99f * r);
                    var ig = (int) (255.99f * g);
                    var ib = (int) (255.99f * b);
                    sw.Write($"{ir} {ig} {ib}\n");
                }
            }
        }
    }
}
