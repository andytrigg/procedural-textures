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
    }
}