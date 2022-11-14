using ImageMagick;

namespace graphical_artifact_comparer
{
    public class PixelReader
	{
        public IEnumerable<string> Read(string filePath)
        {
            MagickImage image = new MagickImage(filePath);
            return image.GetPixelsUnsafe().Select(pixel => pixel.ToColor().ToString());
        }
    }
}

