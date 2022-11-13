using System.Numerics;

namespace graphical_artifact_comparer
{
	public class PixelComparer
	{
        internal BigInteger Compare(ushort[] a, ushort[] b) => a.Length - a.Zip(b, (la, lb) => la == lb).Count(x => x);
    }
}

