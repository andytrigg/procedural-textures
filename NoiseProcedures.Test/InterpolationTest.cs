using NoiseProcedures;
using NUnit.Framework;

namespace NoiseProcedures
{
    public class InterpolationTest
    {
        [Test]
        public void LinearInterpolationShouldReturnTheLowValueWhenAplhpaIsZero()
        {
            Assert.AreEqual(0, Interpolation.Linear(0, 3, 0));            
        }

        [Test]
        public void LinearInterpolationShouldReturnTheHighValueWhenAplhpaIsOne()
        {
            Assert.AreEqual(3, Interpolation.Linear(0, 3, 1));
        }

        [Test]
        public void LinearInterpolationShouldReturnTheMiddleValueWhenAplhpaIsPointFive()
        {
            Assert.AreEqual(1.5F, Interpolation.Linear(0, 3, 0.5F));
        }

        [Test]
        public void LinearInterpolationShouldReturnTheMiddleValueWhenAplhpaIsPointFive2()
        {
            Assert.AreEqual(0.75f, Interpolation.Linear(0, 3, 0.25F));
        }

        [Test]
        public void LinearInterpolationShouldReturnTheMiddleValueWhenAplhpaIsPointFive3()
        {
            Assert.AreEqual(2.25f, Interpolation.Linear(0, 3, 0.75F));
        }

        [TestCase(0F, 1F, 0f, ExpectedResult = 0.0f)]
        [TestCase(0F, 1F, 0.1f, ExpectedResult = 0.024471743f)]
        [TestCase(0F, 1F, 0.2f, ExpectedResult = 0.0954915062f)]
        [TestCase(0F, 1F, 0.3f, ExpectedResult = 0.206107393f)]
        [TestCase(0F, 1F, 0.4f, ExpectedResult = 0.345491499f)]
        [TestCase(0F, 1F, 0.5f, ExpectedResult = 0.5f)]
        [TestCase(0F, 1F, 0.6f, ExpectedResult = 0.654508531f)]
        [TestCase(0F, 1F, 0.7f, ExpectedResult = 0.793892622f)]
        [TestCase(0F, 1F, 0.8f, ExpectedResult = 0.904508531f)]
        [TestCase(0F, 1F, 0.9f, ExpectedResult = 0.97552824f)]
        [TestCase(0F, 1F, 1.0f, ExpectedResult = 1.0f)]
        public float CosineRemapInterpolationShouldReturnAPointOnACurvedLineBasedOnTheCosineFunction(float lo, float high, float alpha)
        {
            return Interpolation.CosineRemap(lo, high, alpha);
        }

        [TestCase(0F, 1F, 0f, ExpectedResult = 0.0f)]
        [TestCase(0F, 1F, 0.1f, ExpectedResult = 0.0280000009f)]
        [TestCase(0F, 1F, 0.2f, ExpectedResult = 0.104000002f)]
        [TestCase(0F, 1F, 0.3f, ExpectedResult = 0.216000021f)]
        [TestCase(0F, 1F, 0.4f, ExpectedResult = 0.352000028f)]
        [TestCase(0F, 1F, 0.5f, ExpectedResult = 0.5f)]
        [TestCase(0F, 1F, 0.6f, ExpectedResult = 0.648000002f)]
        [TestCase(0F, 1F, 0.7f, ExpectedResult = 0.783999979f)]
        [TestCase(0F, 1F, 0.8f, ExpectedResult = 0.896000028f)]
        [TestCase(0F, 1F, 0.9f, ExpectedResult = 0.971999943f)]
        [TestCase(0F, 1F, 1.0f, ExpectedResult = 1.0f)]
        public float SmoothStepRemapInterpolationShouldReturnAPointOnACurvedLineBasedOnASmothStepFunction(float lo, float high, float alpha)
        {
            return Interpolation.SmoothStepRemap(lo, high, alpha);
        }
    }
}