using System;

namespace RayTracing {
    internal static class Program {
        private static void Main() {
            const int nx = 200;
            const int ny = 100;
            Console.Write($"P3\n {nx} {ny}\n255\n");
            for(var j = ny - 1; j >= 0; j--) {
                for(var i = 0; i < nx; i++) {
                    var r = i / (float) nx;
                    var g = j / (float) ny;
                    var b = 0.2f;
                    var ir = (int) (255.99f * r);
                    var ig = (int) (255.99f * g);
                    var ib = (int) (255.99f * b);
                    Console.WriteLine($"{ir} {ig} {ib}\n");
                }
            }
        }
    }
}
