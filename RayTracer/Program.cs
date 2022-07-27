// First step in writing a ray tracer program in C#
// Starting with writing to a PPM file by writing to console
using RayTracer;
using System.Numerics;

// Image sizes - eventually should come from user
const float aspectRatio = 16.0f / 9.0f;
const int imageWidth = 440;
const int imageHeight = (int)(imageWidth / aspectRatio);
const float pixelMax = 255.999f;

// Define the camera
float viewportHeight = 2.0f;
float viewportWidth = aspectRatio * viewportHeight;
float focalLength = 1.0f;

Vector3 origin = new Vector3(0, 0, 0);
Vector3 horizontal = new Vector3(viewportWidth, 0, 0);
Vector3 vertical = new Vector3(0, viewportHeight, 0);
Vector3 focalL = new Vector3(0, 0, focalLength);
Vector3 lower_left_corner = origin - horizontal / 2 - vertical / 2 - focalL;


// Rendering a PPM file with following structure"
// P3
// width height
// pixelMax
// {r g b} {r g b} pixel information
//
Console.WriteLine($"P3\n {imageWidth} {imageHeight} \n255\n");

for (int j = imageHeight - 1; j >= 0; --j)
{
    Console.Error.Write($"\rScanlines remaining: {j}");
    for (int i = 0; i < imageWidth; ++i)
    {
        float r = (float)i / (imageWidth - 1);
        float g = (float)j / (imageHeight - 1);
        float b = 0.25f;

        Vector3 pixelColor = new Vector3(pixelMax * r, pixelMax * g, pixelMax * b);

        Console.WriteLine($"{(int)pixelColor.X} {(int)pixelColor.Y} {(int)pixelColor.Z}");
    }
}
Console.Error.WriteLine("\nDone");

Vector3 orig = new Vector3(1.0f, 1.0f, 1.0f);
Vector3 dirc = new Vector3(2.0f, 4.0f, 8.0f);

Ray ray = new Ray(orig, dirc);
Vector3 neworig = ray.At(4.0f);

System.Console.WriteLine($"{ray.Origin} {ray.Direction}");
System.Console.WriteLine($"{neworig}");
