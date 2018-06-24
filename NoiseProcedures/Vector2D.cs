using System;
using System.Collections.Generic;

namespace NoiseProcedures
{
    public class Vector2D : IEquatable<Vector2D>
    {
        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D operator *(Vector2D original, float scalar) => new Vector2D(original.X * scalar, original.Y * scalar);

        public static bool operator ==(Vector2D d1, Vector2D d2)
        {
            return EqualityComparer<Vector2D>.Default.Equals(d1, d2);
        }

        public static bool operator !=(Vector2D d1, Vector2D d2)
        {
            return !(d1 == d2);
        }

        public float X { get; }
        public float Y { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vector2D);
        }

        public bool Equals(Vector2D other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
