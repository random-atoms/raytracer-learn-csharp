using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public static class ObjectHits
    {
        public static float SphereHit(Vector3 center, float radius, Ray ray)
        {
            Vector3 oc = ray.Origin - center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2.0f * Vector3.Dot(oc, ray.Direction);
            var c = Vector3.Dot(oc, oc) - radius * radius;
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return -1.0f;
            }
            else
            {
                return (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);
            }
        }
    }
}
