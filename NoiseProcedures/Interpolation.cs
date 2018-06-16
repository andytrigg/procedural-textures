using System;

namespace NoiseProcedures
{
    public class Interpolation
    {
        public static float Linear(float low, float high, float alpha) => (1 - alpha) * low + alpha * high;
    }
}
