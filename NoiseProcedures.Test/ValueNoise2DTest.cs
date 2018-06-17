using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoiseProcedures
{
    class ValueNoise2DTest
    {
        private ValueNoise2D valueNoise2D;

        [SetUp]
        protected void SetUp()
        {
            valueNoise2D = new ValueNoise2D();
        }

        [TestCase(0F, ExpectedResult = 0.55625391f)]
        [TestCase(1.0F, ExpectedResult = 0.139868736f)]
        [TestCase(2.0F, ExpectedResult = 0.165970206f)]
        [TestCase(3.0F, ExpectedResult = 0.904059112f)]
        [TestCase(4.0F, ExpectedResult = 0.471912891f)]
        [TestCase(5.0F, ExpectedResult = 0.498461008f)]
        [TestCase(6.0F, ExpectedResult = 0.595048487f)]
        [TestCase(7.0F, ExpectedResult = 0.102574237f)]
        [TestCase(8.0F, ExpectedResult = 0.897243202f)]
        [TestCase(9.0F, ExpectedResult = 0.834620535f)]
        [TestCase(256.0F, ExpectedResult = 0.55625391f)]
        public float ValueNoiseShouldEvaluateForEachCalculatedPointAlongTheXAxis(float x)
        {
            return valueNoise2D.Evaluate(new Vector2D(x, 0f));
        }

        [TestCase(0F, ExpectedResult = 0.55625391f)]
        [TestCase(1.0F, ExpectedResult = 0.868457913f)]
        [TestCase(2.0F, ExpectedResult = 0.232572854f)]
        [TestCase(3.0F, ExpectedResult = 0.381247818f)]
        [TestCase(4.0F, ExpectedResult = 0.423126936f)]
        [TestCase(5.0F, ExpectedResult = 0.665534377f)]
        [TestCase(6.0F, ExpectedResult = 0.285612583f)]
        [TestCase(7.0F, ExpectedResult = 0.721744359f)]
        [TestCase(8.0F, ExpectedResult = 0.496471018f)]
        [TestCase(9.0F, ExpectedResult = 0.42551443f)]
        [TestCase(256.0F, ExpectedResult = 0.55625391f)]
        public float ValueNoiseShouldEvaluateForEachCalculatedPointAlongTheYAxis(float y)
        {
            return valueNoise2D.Evaluate(new Vector2D(0f, y));
        }


        [TestCase(0F, 0f, ExpectedResult = 0.55625391f)]
        [TestCase(53.8f, 73.6f, ExpectedResult = 0.369582355f)]
        [TestCase(256F, 256f, ExpectedResult = 0.55625391f)]
        [TestCase(-256F, -256f, ExpectedResult = 0.55625391f)]
         public float ValueNoiseShouldEvaluateForEachCalculatedPointAnywhereOnAPlain(float x, float y)
        {
            return valueNoise2D.Evaluate(new Vector2D(0f, y));
        }
    }
}
