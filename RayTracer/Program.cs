// First step in writing a ray tracer program in C#
// Starting with writing to a PPM file by writing to console
using RayTracer;
using System.Numerics;

// Image sizes - eventually should come from user

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
Vector3 lowerLeftCorner = origin - (horizontal / 2) - vertical / 2 - focalL;

PPMWriter.GenPPMAsciiOutput(imageHeight, imageWidth, origin, lowerLeftCorner, horizontal, vertical);
