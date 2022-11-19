using HashMap;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashMapTest
{
    public class UnitTest1
    {
        [Fact]
        public void MakesHash()
        {
            Hash<string, int> h = new Hash<string, int>(false);

            Assert.Empty(h);
        }

        [Theory]
        [InlineData("a")]
        public void testAdd1(string s)
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>(s, 3);
            h.Add(pair1);

            Assert.Contains(pair1, h);
        }

        [Fact]

        public void testAddMultiple()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            Assert.Contains(pair1, h);
            Assert.Contains(pair2, h);
        }

        [Fact]
        public void testRemoveInMap()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            h.Remove(pair1);

            Assert.DoesNotContain(pair1, h);
        }

        [Fact]
        public void testRemoveNotInMap()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("j", 9);

            h.Remove(pair3);

            Assert.DoesNotContain(pair3, h);
        }

        [Fact]
        public void testContainsInMap()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("j", 9);
            h.Add(pair3);

            Assert.True((h.Contains(pair3)));
        }

        [Fact]
        public void testContainsNotInMap()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("j", 9);


            Assert.False((h.Contains(pair3)));
        }

        [Fact]
        public void testContainsKeyInMap()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("j", 9);
            h.Add(pair3);


            Assert.True((h.ContainsKey("j")));
        }

        [Fact]
        public void testContainsKeyNotInMap()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("j", 9);


            Assert.False((h.ContainsKey("j")));
        }

        [Fact]
        public void testClear()
        {
            Hash<string, int> h = new Hash<string, int>();
            KeyValuePair<string, int> pair1 = new KeyValuePair<string, int>("c", 3);
            h.Add(pair1);

            KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>("d", 4);
            h.Add(pair2);

            KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>("j", 9);
            h.Add(pair3);

            h.Clear();

            Assert.Empty(h);
        }
    }
}
