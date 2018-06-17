using System;
using System.Diagnostics;

namespace NoiseProcedures
{
    public class Interpolation
    {
        public static float CosineAlpha(float alpha) => (float)((1 - Math.Cos(alpha * Math.PI)) * 0.5);
        public static float SmoothStepAlpha(float alpha) => alpha * alpha * (3 - 2 * alpha);

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
}
