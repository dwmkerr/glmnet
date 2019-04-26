using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlmNet;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// General tests for all matrix types.
    /// </summary>
    [TestFixture]
    [Category("Rank 2 Matrices")]
    class mat2Tests
    {
        [Test]
        public void MatrixIsColumnMajor()
        {
            //  A pretty critical test as this is fundamental.
            var m = new mat2(new[] {
                new vec2(1f, 2f),
                new vec2(3f, 4f)
            });

            //  1 3 
            //  2 4

            Assert.AreEqual(1f, m[0][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(2f, m[0][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(3f, m[1][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(4f, m[1][1], "Matrix does not implement column major semantics");

            Assert.AreEqual(1f, m[0, 0], "Matrix does not implement column major semantics");
            Assert.AreEqual(2f, m[0, 1], "Matrix does not implement column major semantics");
            Assert.AreEqual(3f, m[1, 0], "Matrix does not implement column major semantics");
            Assert.AreEqual(4f, m[1, 1], "Matrix does not implement column major semantics");

            Assert.AreEqual(new vec2(1f, 2f), m[0], "Matrix does not implement column major semantics");
            Assert.AreEqual(new vec2(3f, 4f), m[1], "Matrix does not implement column major semantics");
        }

        [Test]
        public void CanMultiplyByVector()
        {
            var m = new mat2(new[]
            {
                new vec2(1f, 2f),
                new vec2(3f, 4f)
            });
            var v = new vec2(5f, 6f);

            // 1 3 * 5 = 5  18 = 23
            // 2 4   6   10 24 = 34

            Assert.AreEqual(new vec2(23f, 34f), m * v, "Rank 2 Matrix * Vector results are incorrect.");
        }
    }
}
