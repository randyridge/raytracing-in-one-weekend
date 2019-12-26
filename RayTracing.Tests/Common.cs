using System.IO;

namespace RayTracing {
    public static class Common {
        public static Frame BuildTestFrame() {
            var frame = new Frame(3, 2);
            frame.AddColor(NamedColors.Red);
            frame.AddColor(NamedColors.Green);
            frame.AddColor(NamedColors.Blue);

            frame.AddColor(NamedColors.Yellow);
            frame.AddColor(NamedColors.White);
            frame.AddColor(NamedColors.Black);
            return frame;
        }

        public static string GetInputFilePath(string fileName) => Path.Join("TestImages", fileName);

        public static string GetOutputFilePath(string fileName) => Path.Join("OutputImages", fileName);
    }
}
