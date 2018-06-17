using System;

namespace NoiseProcedures
{
    public class ValueNoise2D
    {
        private const int MAX_TABLE_SIZE = 256;
        private const int MAX_TABLE_SIZE_MASK = MAX_TABLE_SIZE - 1;        
        private float[] values = new float[MAX_TABLE_SIZE * MAX_TABLE_SIZE];

        public ValueNoise2D() : this(4251)
        {
        }

        public ValueNoise2D(int seed)
        {
            Random random = new Random(seed);

            // create an array of random values
            for (int i = 0; i < MAX_TABLE_SIZE * MAX_TABLE_SIZE; i++)
            {
                values[i] = (float)random.NextDouble();
            }
        }

        /// <summary>
        /// Evaluates the noise value at position x, y given a noise function. The noise values between the calculated points are 
        /// interpolated based on the function provided.
        /// </summary>
        /// <param name="point">The position whose noise value will be calculated</param>
        /// <returns>Returns a noise value between 0.0f and 1.0f given a positon.</returns>
        public float Evaluate(Vector2D point)
        {
            int xAsInteger = (int) Math.Floor(point.X);
            int yAsInteger = (int) Math.Floor(point.Y);

            float tx = point.X - xAsInteger;
            float ty = point.Y - yAsInteger;

            int rx0 = xAsInteger & MAX_TABLE_SIZE_MASK;
            int rx1 = (rx0 + 1) & MAX_TABLE_SIZE_MASK;
            int ry0 = yAsInteger & MAX_TABLE_SIZE_MASK;
            int ry1 = (ry0 + 1) & MAX_TABLE_SIZE_MASK;

            float corner00 = values[ry0 * MAX_TABLE_SIZE_MASK + rx0];
            float corner10 = values[ry0 * MAX_TABLE_SIZE_MASK + rx1];
            float corner01 = values[ry1 * MAX_TABLE_SIZE_MASK + rx0];
            float corner11 = values[ry1 * MAX_TABLE_SIZE_MASK + rx1];

            // remapping of tx and ty using the Smoothstep function 
            float sx = Interpolation.SmoothStepAlpha(tx);
            float sy = Interpolation.SmoothStepAlpha(ty);

            // linearly interpolate values along the x axis
            float nx0 = Interpolation.Linear(corner00, corner10, sx);
            float nx1 = Interpolation.Linear(corner01, corner11, sx);

            // linearly interpolate the nx0/nx1 along they y axis
            return Interpolation.Linear(nx0, nx1, sy);            
        }
    }
}
