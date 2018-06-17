using System;
using System.Diagnostics;

namespace NoiseProcedures
{
    public class Interpolation
    {        
        private static float CosineAlpha(float alpha) => (float)((1 - Math.Cos(alpha * Math.PI)) * 0.5);
        private static float SmoothStepAlpha(float alpha) => alpha * alpha * (3 - 2 * alpha);

        /// <summary>
        /// Simple Linear interpolation function(lert).
        /// </summary>
        /// <param name="low">The lowest value of the two points</param>
        /// <param name="high">The high value of the two points</param>
        /// <param name="alpha">The fraction between the points whose value will be interoplated based on a linear function. This value should be between 0.0 and 1.0</param>
        /// <returns>The linearly interpolated value.</returns>
        public static float Linear(float low, float high, float alpha) => (1 - alpha) * low + alpha * high;


        /// <summary>
        /// Apply as Cosine remap to a linear interpolation function. 
        /// This well ensure that the nise function is curved rather than having hard edges where the straight lines from linear interpolation would meet.
        /// </summary>
        /// <param name="low">The lowest value of the two points</param>
        /// <param name="high">The high value of the two points</param>
        /// <param name="alpha">The fraction between the points whose value will be interoplated based on a linear function. This value should be between 0.0 and 1.0</param>
        /// <returns>The cosine mapped noise value at the alpha point</returns>
        public static float CosineRemap(float low, float high, float alpha) => Linear(low, high, CosineAlpha(alpha));

        /// <summary>
        /// Apply a smooth step function to a linear interpolation
        /// This well ensure that the nise function is curved and smoother than the cosine equivalent.
        /// </summary>
        /// <param name="low">The lowest value of the two points</param>
        /// <param name="high">The high value of the two points</param>
        /// <param name="alpha">The fraction between the points whose value will be interoplated based on a linear function. This value should be between 0.0 and 1.0</param>
        /// <returns>The smooth step mapped noise value at the alpha point</returns>
        public static float SmoothStepRemap(float low, float high, float alpha) => Linear(low, high, SmoothStepAlpha(alpha));
    }

    public delegate float InterpolationFunction(float low, float high, float alpha);

    public class ValueNoise1D
    {           
        private const int MAX_VERTICES = 256;
        private const int MAX_VERTICES_MASK = MAX_VERTICES - 1;
        private readonly InterpolationFunction interpolationFunction;
        private float[] values = new float[MAX_VERTICES];

        public ValueNoise1D() : this(4251, Interpolation.Linear)
        {
        }

        public ValueNoise1D(int seed, InterpolationFunction interpolationFunction)
        {
            Random random = new Random(seed);
            for (int i = 0; i < MAX_VERTICES; i++)
            {
                values[i] = (float)random.NextDouble();
            }

            this.interpolationFunction = interpolationFunction;
        }
            
        /// <summary>
        /// Evaluates the noise function at position x. The noise values between the calculated points are 
        /// linearly interpolated so the noise appears smooth rather than random.
        /// </summary>
        /// <param name="x">The position whise noise value will be calculated</param>
        /// <returns>Returns a noise value between 0.0f and 1.0f given a positon of x.</returns>
        public float Evaluate(float x)
        {
            // Floor
            int xAsInteger = (x < 0 && x != (int)x) ? (int)x - 1 : (int)x;
            float t = x - xAsInteger;

            // Modulo using &
            int minimumX = xAsInteger & MAX_VERTICES_MASK;
            int maximumX = (minimumX + 1) & MAX_VERTICES_MASK;
            return interpolationFunction(values[minimumX], values[maximumX], t);
        }
    }
}
