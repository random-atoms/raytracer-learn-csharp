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
            var t = ObjectHits.SphereHit(new Vector3(0, 0, -1), 0.5f, this);
            if (t > 0.0f)
            {
                Vector3 N = At(t) - new Vector3(0, 0, -1);
                return 0.5f * new Vector3(N.X + 1.0f, N.Y + 1.0f, N.Z + 1.0f);
            }    

            Vector3 unitDir = Vector3.Normalize(Direction);
            t = 0.5f * (unitDir.Y + 1.0f);
            Vector3 finalColor =  (1.0f - t) * new Vector3(1.0f) + t * new Vector3(0.5f, 0.7f, 1.0f);
            return finalColor;
        }
    }
}
