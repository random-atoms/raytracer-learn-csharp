using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    internal static class PPMWriter
    {
        const float pixelMax = 255.999f;

        public static void GenPPMAsciiOutput(int imageHeight, int imageWidth, Vector3 origin, Vector3 llc, Vector3 hzt, Vector3 vrt)
        {

            // Rendering a PPM file with following structure"
            // P3
            // width height
            // pixelMax
            // {r g b} {r g b} pixel information
            //
            Console.WriteLine($"P3\n{imageWidth} {imageHeight}\n255\n");

            for (int j = imageHeight - 1; j >= 0; --j)
            {
                Console.Error.Write($"\rScanlines remaining: {j}");
                for (int i = 0; i < imageWidth; ++i)
                {
                    float u = (float)i / (imageWidth - 1);
                    float v = (float)j / (imageHeight - 1);

                    Ray ray = new Ray(origin, llc + u * hzt + v * vrt - origin);

                    // Multiply ray color by pixelMax to get pixelColor
                    Vector3 pixelColor = pixelMax * ray.GetColor();


                    Console.WriteLine($"{(int)pixelColor.X} {(int)pixelColor.Y} {(int)pixelColor.Z}");
                }
            }
            Console.Error.WriteLine("\nDone");
        }
    }
}
