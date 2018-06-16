using System;
using System.Diagnostics;

namespace NoiseProcedures
{
    public class Interpolation
    {
        /// <summary>
        /// Simple Linear interpolation function(lert).
        /// </summary>
        /// <param name="low">The lowest value of the two points</param>
        /// <param name="high">The high value of the two points</param>
        /// <param name="alpha">The fraction between the points whose value will be interoplated based on a linear function. This value should be between 0.0 and 1.0</param>
        /// <returns>The linearly interpolated value.</returns>
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
            
        /// <summary>
        /// Evaluates the noise function at position x. The noise values between the calculated points are 
        /// linearly interpolated so the noise appears smooth rather than random.
        /// </summary>
        /// <param name="x">The position whise noise value will be calculated</param>
        /// <returns>Returns a noise value between 0.0f and 1.0f given a positon of x.</returns>
        public float Evaluate(float x)
        {
            int xMin = (int)x;
            Debug.Assert(xMin <= MAX_VERTICES - 1);

            float t = x - xMin;
            return Interpolation.Linear(values[xMin], values[xMin +1], t);
        }
    }
}
