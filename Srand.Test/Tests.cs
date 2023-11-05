namespace Srand.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Persistency()
        {
            // generated expected
            var srand = new SeededRandom(12345);
            var expected = new double[100];
            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = srand.NextDouble();
            }

            // do test
            srand = new SeededRandom(12345);
            foreach (var ex in expected)
            {
                Assert.That(ex, Is.EqualTo(srand.NextDouble()));
            }
        }

        [Test]
        public void NextDouble()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            var min = 1.0;
            var max = 0.0;
            for(var i = 0; i < 100000; ++i)
            {
                var val = srand.NextDouble();
                min = Math.Min(min, val);
                max = Math.Max(max, val);
                Assert.IsTrue(val < 1 && val >= 0, $"Got illegal value {val}");
            }
            Assert.IsTrue(min <= 0.1, $"Numbers are not random enough, min is {min}");
            Assert.IsTrue(max >= 0.9, $"Numbers are not random enough, max is {max}");
            Assert.Pass();
        }

        [Test]
        public void NextSingle()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            var min = 1.0f;
            var max = 0.0f;
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.NextSingle();
                min = MathF.Min(min, val);
                max = MathF.Max(max, val);
                Assert.IsTrue(val < 1f && val >= 0f, $"Got illegal value {val}");
            }
            Assert.IsTrue(min <= 0.1, $"Numbers are not random enough, min is {min}");
            Assert.IsTrue(max >= 0.9, $"Numbers are not random enough, max is {max}");
            Assert.Pass();
        }

        [Test]
        public void NextBytes()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            for (var i = 0; i < 100000; ++i)
            {
                var bytes = new byte[10];
                srand.NextBytes(bytes);
            }
            Assert.Pass();
        }

        [Test]
        public void NextBytesBySize()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            for (var i = 0; i < 100000; ++i)
            {
                srand.NextBytes(10);
            }
            Assert.Pass();
        }

        [Test]
        public void Pick()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            
            var list = new List<int> { 1, 2, 3, 4, 5 };
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.Pick(list);
                Assert.IsTrue(val <= 5 && val >= 1, $"Got illegal value {val}");
            }

            var arr = new int[] { 1, 2, 3, 4, 5 };
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.Pick(arr);
                Assert.IsTrue(val <= 5 && val >= 1, $"Got illegal value {val}");
            }

            Assert.Pass();
        }

        [Test]
        public void Next()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            var min = int.MaxValue;
            var max = 0;
            for (var i = 0; i < 1000000; ++i)
            {
                var val = srand.Next();
                min = Math.Min(min, val);
                max = Math.Max(max, val);
                Assert.IsTrue(val < int.MaxValue && val >= 0, $"Got illegal value {val}");
            }
            Assert.IsTrue(min <= 10000, $"Numbers are not random enough, min is {min}");
            Assert.IsTrue(max >= (int.MaxValue - 10000), $"Numbers are not random enough, max is {max}");
            Assert.Pass();
        }

        [Test]
        public void NextUint()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            uint min = uint.MaxValue;
            uint max = 0;
            for (var i = 0; i < 1000000; ++i)
            {
                var val = srand.NextUint();
                min = Math.Min(min, val);
                max = Math.Max(max, val);
                Assert.IsTrue(val < uint.MaxValue && val >= 0, $"Got illegal value {val}");
            }
            Assert.IsTrue(min <= 50000, $"Numbers are not random enough, min is {min}");
            Assert.IsTrue(max >= (uint.MaxValue - 50000), $"Numbers are not random enough, max is {max}");
            Assert.Pass();
        }

        [Test]
        public void NextWithMax()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.Next(50);
                Assert.IsTrue(val < 50 && val >= 0, $"Got illegal value {val}");
            }
            for (var i = 0; i < 1000; ++i)
            {
                var val = srand.Next(1);
                Assert.IsTrue(val == 0, $"Got illegal value {val}");
            }
            Assert.Pass();
        }

        [Test]
        public void NextWithMinMax()
        {
            var srand = new SeededRandom(Random.Shared.Next());
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.Next(10, 50);
                Assert.IsTrue(val < 50 && val >= 10, $"Got illegal value {val}");
            }
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.Next(-10, 50);
                Assert.IsTrue(val < 50 && val >= -10, $"Got illegal value {val}");
            }
            for (var i = 0; i < 100000; ++i)
            {
                var val = srand.Next(-10, 0);
                Assert.IsTrue(val < 0 && val >= -10, $"Got illegal value {val}");
            }
            for (var i = 0; i < 100; ++i)
            {
                var val = srand.Next(10, 10);
                Assert.IsTrue(val == 10, $"Got illegal value {val}");
            }
            Assert.Pass();
        }
    }
}