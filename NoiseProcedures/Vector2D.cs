namespace NoiseProcedures
{
    public class Vector2D
    {
        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D operator *(Vector2D original, float scalar) => new Vector2D(original.X * scalar, original.Y * scalar);

        public float X { get; }
        public float Y { get; }
    }
}
