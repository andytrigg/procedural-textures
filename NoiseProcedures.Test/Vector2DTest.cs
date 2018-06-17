using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoiseProcedures.Test
{
    class Vector2DTest
    {
        [Test]
        public void Vector2DCanBeMultipliedByZero()
        {
            Vector2D original = new Vector2D(1, 2);
            Vector2D result = original * 0;
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
        }

        [Test]
        public void Vector2DCanBeMultipliedByPositiveScalar()
        {
            Vector2D original = new Vector2D(1, 2);
            Vector2D result = original * 7;
            Assert.AreEqual(7f, result.X);
            Assert.AreEqual(14f, result.Y);
        }

        [Test]
        public void Vector2DCanBeMultipliedByANegativeScalar()
        {
            Vector2D original = new Vector2D(1, 2);
            Vector2D result = original * -7;
            Assert.AreEqual(-7f, result.X);
            Assert.AreEqual(-14f, result.Y);
        }
    }
}
