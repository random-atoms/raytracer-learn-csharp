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

        public Vector3 GetColor()
        {
            if (ObjectHits.SphereHit())
            {
                return new Vector3(1, 0, 0);
            }
            Vector3 unitDir = Vector3.Normalize(Direction);
            float t = 0.5f * (unitDir.Y + 1.0f);
            Vector3 tmpUnitColor = new Vector3(1.0f);
            Vector3 tmpOtherColor = new Vector3(0.5f,0.7f,1.0f);
            Vector3 finalColor =  (1.0f - t) * tmpUnitColor + t * tmpOtherColor;
            return finalColor;
        }
    }
}
