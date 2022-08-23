using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public struct HitRecord
    {
        public Vector3 Point {  get; set; }
        public Vector3 Normal { get; set; }
        public float T {  get; set; }

        public bool FrontFace;
    
        public void SetFaceNormal (Ray ray, Vector3 outwardNormal)
        {
            FrontFace = Vector3.Dot(ray.Direction, outwardNormal) < 0;
            if (FrontFace)
            {
                Normal = outwardNormal;
            }
            else
            {
                Normal = -outwardNormal;
            }
        }

    }

    public interface Hittable
    {
        public bool Hit(Ray ray, float tMin, float tMax, out HitRecord hR);
    }
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
    public class Sphere : Hittable
    {
        public Vector3 Center { get; }
        public float Radius { get;  }
        Sphere(Vector3 center, float radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
        public bool Hit(Ray ray, float tMin, float tMax, out HitRecord hR)
        {
            hR = new HitRecord();

            Vector3 oc = ray.Origin - Center;
            var a = ray.Direction.LengthSquared();
            var halfB = Vector3.Dot(oc, ray.Direction);
            var c = oc.LengthSquared() - Radius * Radius;
            var discriminant = halfB * halfB - a * c;
            if (discriminant < 0)
            {
                return false;
            }
            var sqrtD = (float)Math.Sqrt(discriminant);


            // Find the nearest root that lies in the acceptable range.
            var root = (-halfB - sqrtD) / a;
            if (root < tMin || tMax < root)
            {
                root = (-halfB + sqrtD) / a;
                if (root < tMin || tMax < root)
                    return false;
            }

            hR.T = root;
            hR.Point = ray.At(hR.T);
            Vector3 outwardNormal = (hR.Point - Center) / Radius;
            hR.SetFaceNormal(ray, outwardNormal);

            return true;
   
        }
    }

    public class HittableObjects : Hittable, IEquatable<Hittable>
    {
        public bool Hit(Ray ray, float tMin, float tMax, out HitRecord hR)
        {
            hR = new HitRecord();
            return false;
        }
        public override bool Equals(Hittable other)
        {
            if (other == null) return false;
            else return true;
        }
    }
}
