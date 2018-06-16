using System;
using System.Diagnostics;

namespace NoiseProcedures
{
    public class Interpolation
    {
        public static float Linear(float low, float high, float alpha) => (1 - alpha) * low + alpha * high;
    }

    public class ValueNoise1D
    {
        private const int MAX_VERTICES = 10;
        private float[] values = new float[MAX_VERTICES];

        public ValueNoise1D() : this(4251)
        {
        }

        public ValueNoise1D(int seed )
        {
            Random random = new Random(seed);
            for (int i = 0; i < MAX_VERTICES; i++)
            {
                values[i] = (float)random.NextDouble();
            }
        }
            
        public float Evaluate(float x)
        {
            int xMin = (int)x;
            Debug.Assert(xMin <= MAX_VERTICES - 1);

            float t = x - xMin;
            return Interpolation.Linear(values[xMin], values[xMin +1], t);
        }
    }
}
