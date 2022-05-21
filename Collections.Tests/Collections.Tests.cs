using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class CollectionsTests
    {
        private static int[] testRangeInput;
        private static string testRangeInputString;

        [OneTimeSetUp]
        public void SetUp()
        {
            testRangeInput = new int[] { 15, 19, 16, 0, 20, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            testRangeInputString = string.Join(", ", testRangeInput);
        }

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var nums = new Collection<int>();
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);
            Assert.That(nums[0], Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 10, 15);

            Assert.That(nums[0], Is.EqualTo(5));
            Assert.That(nums[1], Is.EqualTo(10));
            Assert.That(nums[2], Is.EqualTo(15));
        }

        [Test]
        public void Test_Collection_Add()
        {
            var nums = new Collection<int>();
            nums.Add(15);
            nums.Add(25);

            Assert.That(nums.ToString, Is.EqualTo("[15, 25]"));
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.Add(12);

            Assert.That(nums.ToString(), Is.EqualTo($"[{testRangeInputString}, 12]"));
            Assert.That(nums.Capacity, Is.EqualTo(32));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16, 0, 20);

            Assert.That(nums[0], Is.EqualTo(15));
            Assert.That(nums[1], Is.EqualTo(19));
            Assert.That(nums[2], Is.EqualTo(16));
            Assert.That(nums[3], Is.EqualTo(0));
            Assert.That(nums[4], Is.EqualTo(20));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);

            for (int i = 0; i < testRangeInput.Length; i++)
            {
                Assert.That(nums[i], Is.EqualTo(testRangeInput[i]));
            }
        }

        [Test]
        public void Test_Collection_GetByIndexString()
        {
            var items = new Collection<string>();
            var input = new string[] { "baby", "house", "bird", "pizza", "cake" };
            items.AddRange(input);

            for (int i = 0; i < input.Length; i++)
            {
                Assert.That(items[i], Is.EqualTo(input[i]));
            }
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);

            Assert.That(() => { var index = nums[33]; }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums[4] = 33;

            Assert.That(nums[4], Is.EqualTo(33));
        }

        [Test]
        public void Test_Collection_SetByIndexString()
        {
            var items = new Collection<string>();
            items.AddRange("baby", "house", "bird", "pizza", "cake");
            items[2] = "ball";
            items[4] = "head";

            Assert.That(items.ToString, Is.EqualTo("[baby, house, ball, pizza, head]"));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndexMax()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);

            Assert.That(() => { var num = nums[17]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByInvalidIndexMin()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);

            Assert.That(() => { var index = nums[-1]; }, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow1()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.AddRange(12);
            nums.AddRange(testRangeInput);

            Assert.That(nums.ToString(), Is.EqualTo($"[{testRangeInputString}, 12, {testRangeInputString}]"));
            Assert.That(nums.Capacity, Is.EqualTo(64));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow2()
        {
            var nums = new Collection<int>();
            var oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);

            var expectedNums = "[" + string.Join(", ", newNums) + "]";

            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.InsertAt(0, 7);

            Assert.That(nums[0], Is.EqualTo(7));
            Assert.That(nums[1], Is.EqualTo(15));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.AddRange(12, 15, 19, 16);
            nums.InsertAt(20, 1);

            Assert.That(nums[19], Is.EqualTo(16));
            Assert.That(nums[20], Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.InsertAt(8, 10);

            Assert.That(nums[8], Is.EqualTo(10));
            Assert.That(nums[10], Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.AddRange(12, 15, 19, 16);
            nums.InsertAt(20, 1);

            Assert.That(nums[19], Is.EqualTo(16));
            Assert.That(nums[20], Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);

            Assert.That(() => { nums.InsertAt(17, 0); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.Exchange(7, 8);

            Assert.That(nums[7], Is.EqualTo(4));
            Assert.That(nums[8], Is.EqualTo(3));
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.Exchange(0, 15);

            Assert.That(nums[0], Is.EqualTo(11));
            Assert.That(nums[15], Is.EqualTo(15));
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);

            Assert.That(() => { nums.Exchange(0, 17); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var nums = new Collection<int>();
            nums.AddRange(testRangeInput);
            nums.RemoveAt(0);

            Assert.That(nums[0], Is.EqualTo(19));
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16, 0, 20, 1, 2, 3, 4, 5, 6);
            nums.RemoveAt(10);

            Assert.That(nums[9], Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16, 0, 20, 1, 2, 3, 4, 5, 6);
            nums.RemoveAt(5);

            Assert.That(nums[5], Is.EqualTo(2));
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16, 0, 20, 1, 2, 3, 4, 5, 6);

            Assert.That(() => { nums.RemoveAt(11); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            var itemsCount = 5;
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16, 9, 8);

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                nums.RemoveAt(i);
            }

            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16);
            nums.Clear();

            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var nums = new Collection<int>();
            nums.AddRange(15, 19, 16);

            var capacity = nums.Capacity;
            var count = nums.Count;

            Assert.That(capacity, Is.EqualTo(16));
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void Test_Collection_CountAndCapacityInvalid()
        {
            var nums = new Collection<int>();
            var count = 0;

            for (int i = 0; i < 20; i++)
            {
                nums.Add(i);
                count++;
            }

            Assert.That(nums.Capacity, Is.EqualTo(32));
            Assert.That(count, Is.EqualTo(20));
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var names = new Collection<string>();
            Assert.That(names.ToString, Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var names = new Collection<string>("Sisi");
            Assert.That(names[0], Is.EqualTo("Sisi"));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var names = new Collection<string>("Sisi", "Kate", "Peter", "Nasko");
            names.Add(item: "Kana");

            Assert.That(names.ToString(), Is.EqualTo("[Sisi, Kate, Peter, Nasko, Kana]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("car", "house");
            var nums = new Collection<int>(10, 20);
            var decimalNums = new Collection<double>(5.5, 10.7);
            var nested = new Collection<object>(names, nums, decimalNums);
            var nestedToString = nested.ToString();

            Assert.That(nestedToString, Is.EqualTo("[[car, house], [10, 20], [5.5, 10.7]]"));
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            var itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                nums.RemoveAt(i);
            }

            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }
    }
}