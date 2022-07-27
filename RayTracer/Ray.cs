using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RayTracer
{
    public class Ray
    {
        public Ray(Vector3 orig, Vector3 dir)
        {
            Origin = orig;
            Direction = dir;
        }
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }

        public Vector3 At(float t)
        {
            return Origin + Direction * t;
        }

        Vector3 GetColor()
        {
            return new Vector3();
        }
    }
}
