using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Averager.Tests
{
    public class AverageTests
    {

        public Averager Averager { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Averager = new Averager();
        }

        [Test]
        public void Test_Average_Ok()
        {
            var arr = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = 5.5;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Average_Negative_Numbers()
        {
            var arr = new double[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            var expected = -5.5;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Average_Negative_And_Positive_Numbers()
        {
            var arr = new double[] { -5, 10, -3, 20 };
            var expected = 5.5;
            var actual =Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Average_Period_Result()
        {
            var arr = new double[] { 15, 10, 6 };
            var expected = 10.33;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Average_Array_Consisting_0()
        {
            var arr = new double[] { -5, 10, 0, 9, -8 };
            var expected = 1.2;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test_Average_Array_With_Much_Equal_Numbers()
        {
            var arr = new double[] { 5, 5, 5, 5, 5 };
            var expected = 5.0;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Average_Negative_Result()
        {
            var arr = new double[] { -10, -25, 30 };
            var expected = -1.67;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Average_Array_Includind_Decimal_Nums()
        {
            var arr = new double[] { -10, -25.5, 30 };
            var expected = -1.83;
            var actual = Averager.Average(arr);
            Assert.AreEqual(expected, actual);
        }
    }
}