using System;

namespace NoiseProcedures
{
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
        /// Evaluates the noise value at position x. The noise values between the calculated points are 
        /// interpolated isong a function provided.
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
