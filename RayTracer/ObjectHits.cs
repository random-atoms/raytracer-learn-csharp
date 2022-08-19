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
            var halfB = Vector3.Dot(oc, ray.Direction);
            var c = oc.LengthSquared() - radius * radius;
            var discriminant = halfB * halfB - a * c;
            if (discriminant < 0)
            {
                return -1.0f;
            }
            else
            {
                return (-halfB - (float)Math.Sqrt(discriminant)) / a;
            }
        }
    }
}
