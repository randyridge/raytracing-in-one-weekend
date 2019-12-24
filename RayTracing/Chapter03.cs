using System.Collections.Generic;
using System.Numerics;

namespace RayTracing {
    public static class Chapter03 {
        public static List<Color> Run(int width, int height) {
            var buffer = new List<Color>(width * height);
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var col = new Vector3(i / (float) width, j / (float) height, 0.2f);
                    var ir = (byte) (255.99f * col.X);
                    var ig = (byte) (255.99f * col.Y);
                    var ib = (byte) (255.99f * col.Z);
                    buffer.Add(new Color(ir, ig, ib));
                }
            }
            return buffer;
        }
    }
}
