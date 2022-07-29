// First step in writing a ray tracer program in C#
// Starting with writing to a PPM file by writing to console
using RayTracer;
using System.Numerics;

// Image sizes - eventually should come from user
const float pixelMax = 255.999f;
const float aspectRatio = 16.0f / 9.0f;
const int imageWidth = 400;
const int imageHeight = (int)(imageWidth / aspectRatio);

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
        float u = (float)i / (imageWidth - 1);
        float v = (float)j / (imageHeight - 1);

        Ray ray = new Ray(origin, lower_left_corner + u * horizontal + v * vertical - origin);

        // Multiply ray color by pixelMax to get pixelColor
        Vector3 pixelColor = pixelMax * ray.GetColor();


        Console.WriteLine($"{(int)pixelColor.X} {(int)pixelColor.Y} {(int)pixelColor.Z}");
    }
}
Console.Error.WriteLine("\nDone");
