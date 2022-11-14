using CommandLine;
using graphical_artifact_comparer;

namespace App;

public class Program
{
    public class Options
    {
        [Option('o', "original", Required = true, HelpText = "Original file")]
        public string? Original { get; set; }

        [Option('c', "compressed", Required = true, HelpText = "Compressed file")]
        public string? Compressed { get; set; }
    }

    public static void Main(string[] args)
    {
        string originalFilePath = "";
        string compressedFilePath = "";

        Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {
                       originalFilePath = o.Original ?? "";
                       compressedFilePath = o.Compressed ?? "";
                   });

        if (string.IsNullOrWhiteSpace(originalFilePath) || !File.Exists(originalFilePath))
        {
            Console.WriteLine($"please provide a valid original file path instead of {originalFilePath}");
            return;
        }

        if (string.IsNullOrWhiteSpace(compressedFilePath) || !File.Exists(compressedFilePath))
        {
            Console.WriteLine($"please provide a valid compressed file path instead of {compressedFilePath}");
            return;
        }

        Console.WriteLine("Searching for graphical artifacts...");

        PixelReader pixelReader = new PixelReader();
        IEnumerable<string> originalFilePixels = pixelReader.Read(originalFilePath);
        IEnumerable<string> compressedFilePixels = pixelReader.Read(compressedFilePath);

        int nonEqualPixels = new PixelComparer().Compare(originalFilePixels, compressedFilePixels);

        Console.WriteLine("Searching for difference hash similarity...");

        DHasher dhash = new DHasher();
        ulong originalFileHash = dhash.CalculateDifferenceHash(originalFilePath);
        ulong differenceFileHash = dhash.CalculateDifferenceHash(compressedFilePath);

        double differenceRatio = dhash.CalculateImageDifferences(originalFileHash, differenceFileHash);

        Console.WriteLine($"There are {nonEqualPixels} graphical artifacts");
        Console.WriteLine($"Similarity ratio: {differenceRatio}%");
    }
}