namespace RayTracing {
    public static class Chapter02 {
        public static void FillFrame(in Frame frame) {
            var height = frame.Height;
            var width = frame.Width;
            for(var j = height - 1; j >= 0; j--) {
                for(var i = 0; i < width; i++) {
                    frame.AddColor(new Color(i / (float) width, j / (float) height, 0.2f));
                }
            }
        }
    }
}
