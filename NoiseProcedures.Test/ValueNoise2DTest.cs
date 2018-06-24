using Moq;
using NUnit.Framework;

namespace NoiseProcedures
{
    class FrequencyDecoratorTest
    {
        [Test]
        public void FrequencyDecoratorShouldImplementTheValueNoiseInterface()
        {
            var innerMock = new Mock<IValueNoise2d>();

            FrequencyDecorator frequencyDecorator = new FrequencyDecorator(innerMock.Object);
            Assert.IsInstanceOf<IValueNoise2d>(frequencyDecorator);
        }

        [Test]
        public void FrequencyDecoratorShouldApplyADefaultFrequencyThatHasNoImpact()
        {
            const int InnerNoiseValue = 3;

            var innerMock = new Mock<IValueNoise2d>();
            innerMock.Setup(inner => inner.Evaluate(new Vector2D(3.0f, 3.0f))).Returns(InnerNoiseValue);

            FrequencyDecorator frequencyDecorator = new FrequencyDecorator(innerMock.Object);
            Assert.AreEqual(InnerNoiseValue, frequencyDecorator.Evaluate(new Vector2D(3.0f, 3.0f)));
        }

        [Test]
        public void FrequencyDecoratorShouldApplyACustomFrequencyOnTheVectorBeforeTheNoiseBeingEvaluated()
        {
            const int InnerNoiseValue = 3;

            var innerMock = new Mock<IValueNoise2d>();
            innerMock.Setup(inner => inner.Evaluate(new Vector2D(1.5f, 1.5f))).Returns(InnerNoiseValue);

            FrequencyDecorator frequencyDecorator = new FrequencyDecorator(innerMock.Object, 0.5f);
            Assert.AreEqual(InnerNoiseValue, frequencyDecorator.Evaluate(new Vector2D(3.0f, 3.0f)));
        }
    }

    class AmplitudeDecoratorTest
    {
        [Test]
        public void AmplitudeDecoratorShouldImplementTheValueNoiseInterface()
        {
            var innerMock = new Mock<IValueNoise2d>();

            AmplitudeDecorator amplitudeDecorator = new AmplitudeDecorator(innerMock.Object);
            Assert.IsInstanceOf<IValueNoise2d>(amplitudeDecorator);
        }

        [Test]
        public void AmplitudeDecoratorShouldApplyADefaultAmplitudeThatHasNoImpact()
        {
            const int InnerNoiseValue = 3;

            var innerMock = new Mock<IValueNoise2d>();
            innerMock.Setup(inner => inner.Evaluate(new Vector2D(3.0f, 3.0f))).Returns(InnerNoiseValue);

            AmplitudeDecorator amplitudeDecorator = new AmplitudeDecorator(innerMock.Object);
            Assert.AreEqual(InnerNoiseValue, amplitudeDecorator.Evaluate(new Vector2D(3.0f, 3.0f)));
        }

        [Test]
        public void AmplitudeDecoratorShouldApplyACustomAmplitudeOnTheResultOfTheNoiseBeingEvaluated()
        {
            var innerMock = new Mock<IValueNoise2d>();
            innerMock.Setup(inner => inner.Evaluate(new Vector2D(3.0f, 3.0f))).Returns(3.0f);

            AmplitudeDecorator amplitudeDecorator = new AmplitudeDecorator(innerMock.Object, 0.5f);
            Assert.AreEqual(1.5f, amplitudeDecorator.Evaluate(new Vector2D(3.0f, 3.0f)));
        }
    }

    class ValueNoise2DTest
    {
        private ValueNoise2D valueNoise2D;

        [SetUp]
        protected void SetUp()
        {
            valueNoise2D = new ValueNoise2D();
        }

        [Test]
        public void ValueNoise2dShouldImplementTheValueNoiseInterface()
        {
            Assert.IsInstanceOf<IValueNoise2d>(valueNoise2D);
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
