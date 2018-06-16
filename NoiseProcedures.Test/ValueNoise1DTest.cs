using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoiseProcedures
{
    class ValueNoise1DTest
    {
        private ValueNoise1D valueNoise1D;

        [SetUp]    
        protected void SetUp()
        {
            valueNoise1D = new ValueNoise1D();
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
        public float ValueNoiseShouldEvaluateForEachCalculatedPoint(float x)
        {           
            return valueNoise1D.Evaluate(x);
        }

        [TestCase(0.5f, 0.55625391f, 0.139868736f)]
        public void ValueNoiseShouldEvaluateMidPointsUsingLinerInterpolation(float x, float low, float high)
        {
            float expectedValue = Interpolation.Linear(low, high, x);
            Assert.AreEqual(expectedValue, valueNoise1D.Evaluate(x));
        }
 
    }
}
