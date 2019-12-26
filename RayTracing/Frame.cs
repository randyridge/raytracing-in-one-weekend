using System.Collections.Generic;
using RandyRidge.Common;

namespace RayTracing {
    public readonly struct Frame {
        private readonly List<Color> colors;

        public Frame(int width, int height) {
            Width = Guard.MinimumInclusive(width, 1, nameof(width));
            Height = Guard.MinimumInclusive(height, 1, nameof(height));
            colors = new List<Color>(width * height);
        }

        internal IList<Color> Colors => colors;

        public int Height { get; }

        public int Width { get; }

        public void AddColor(in Color color) {
            colors.Add(color);
        }
    }
}
