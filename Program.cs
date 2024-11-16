using System;
using System.IO;
using Svg.Skia;
using SkiaSharp;

namespace SvgToRaster
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: svg-to-raster <input-svg-file> [output-file] [output-format]");
                return;
            }

            string inputFilePath = args[0];
            string outputFilePath = args.Length > 1 ? args[1] : Path.ChangeExtension(inputFilePath, "png");
            string outputFormat = args.Length > 2 ? args[2].ToLower() : "png";

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Error: Input file '{inputFilePath}' does not exist.");
                return;
            }

            try
            {
                using (var svg = new SKSvg())
                {
                    svg.Load(inputFilePath);

                    var bitmap = new SKBitmap((int)svg.Picture.CullRect.Width, (int)svg.Picture.CullRect.Height);
                    var canvas = new SKCanvas(bitmap);
                    canvas.Clear(SKColors.Transparent);
                    canvas.DrawPicture(svg.Picture);
                    canvas.Flush();

                    SKEncodedImageFormat format = outputFormat switch
                    {
                        "jpeg" => SKEncodedImageFormat.Jpeg,
                        "gif" => SKEncodedImageFormat.Gif,
                        _ => SKEncodedImageFormat.Png,
                    };

                    using (var image = SKImage.FromBitmap(bitmap))
                    using (var data = image.Encode(format, 100))
                    using (var stream = File.OpenWrite(outputFilePath))
                    {
                        data.SaveTo(stream);
                    }
                }

                Console.WriteLine($"Successfully converted '{inputFilePath}' to '{outputFilePath}' in {outputFormat} format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
