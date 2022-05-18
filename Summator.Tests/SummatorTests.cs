using NUnit.Framework;

namespace Summator.Tests
{
    public class SummatorTests
    {
        public Summator Summator { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Summator = new Summator();
        }

        [Test]
        public void Test_SumTwoPositiveNumbers()
        {
            var sum = Summator.Sum(new int[] { 1, 2 });
            Assert.AreEqual(3, sum);
        }

        [Test]
        public void Test_SumPositiveAndNegativeNumbers()
        {
            var sum = Summator.Sum(new int[] { 10, -5 });
            Assert.AreEqual(5, sum);
        }

        [Test]
        public void Test_SumTwoNegativeNumbers()
        {
            var sum = Summator.Sum(new int[] { -9, -100 });
            Assert.That(sum == -109);
        }

        [Test]
        public void Test_Sum_With_Bool()
        {
            var isTrue = false;
            var sum = Summator.Sum(new int[] { 16, 19, -3 });
            if (sum == 32)
            {
                isTrue = true;
            }
            Assert.IsTrue(isTrue);
        }

        [Test]
        public void Test_SumBigValues()
        {
            var expected = Summator.Sum(new int[] { 2000000000, 2000000000, 2000000000 });
            Assert.AreEqual(expected, 1705032704);
        }

        [Test]
        public void Test_SumTwoNegativeNumbersRange()
        {
            var expected = Summator.Sum(new int[] { 10, 53 });
            Assert.That(expected, Is.InRange(60, 70));
        }
    }
}
