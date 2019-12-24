using System.Collections.Generic;

namespace RayTracing {
    public static class Chapter02 {
        public static List<Color> Run(int width, int height) {
            var buffer = new List<Color>(width * height);
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var r = i / (float) width;
                    var g = j / (float) height;
                    var b = 0.2f;
                    var ir = (byte) (255.99f * r);
                    var ig = (byte) (255.99f * g);
                    var ib = (byte) (255.99f * b);
                    buffer.Add(new Color(ir, ig, ib));
                }
            }
            return buffer;
        }
    }
}
