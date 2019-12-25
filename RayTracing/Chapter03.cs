using System.Numerics;

namespace RayTracing {
    public static class Chapter03 {
        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var col = new Vector3(i / (float) width, j / (float) height, 0.2f);
                    var ir = (byte) (255.99f * col.X);
                    var ig = (byte) (255.99f * col.Y);
                    var ib = (byte) (255.99f * col.Z);
                    frame.AddColor(new Color(ir, ig, ib));
                }
            }
        }
    }
}
