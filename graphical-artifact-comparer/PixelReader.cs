using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ImageMagick;

namespace graphical_artifact_comparer
{
	public class PixelReader
	{
        internal ushort[] Read(string filePath)
        {
            MagickImage image = new MagickImage(filePath);
            return image.GetPixels().ToArray() ?? Array.Empty<ushort>();
        }
    }
}

