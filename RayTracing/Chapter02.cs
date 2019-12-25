namespace RayTracing {
    public static class Chapter02 {
        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    var r = i / (float) width;
                    var g = j / (float) height;
                    var b = 0.2f;
                    var ir = (byte) (255.99f * r);
                    var ig = (byte) (255.99f * g);
                    var ib = (byte) (255.99f * b);
                    frame.AddColor(new Color(ir, ig, ib));
                }
            }
        }
    }
}
