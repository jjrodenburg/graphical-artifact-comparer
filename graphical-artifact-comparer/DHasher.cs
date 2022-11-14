using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;

namespace graphical_artifact_comparer
{
	public class DHasher
	{
		public ulong CalculateDifferenceHash(string filePath)
		{
			DifferenceHash hashAlgorithm = new DifferenceHash();
            using FileStream stream = File.OpenRead(filePath);

			return hashAlgorithm.Hash(stream);
        }

        public double CalculateImageDifferences(ulong hash1, ulong hash2) => CompareHash.Similarity(hash1, hash2);
    }
}

