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
    [Category("Rank 3 Matrices")]
    class mat3Tests
    {
        [Test]
        public void MatrixIsColumnMajor()
        {
            //  A pretty critical test as this is fundamental.
            var m = new mat3(new[] {
                new vec3(1f, 2f, 3f),
                new vec3(4f, 5f, 6f),
                new vec3(7f, 8f, 9f)
            });

            //  1 4 7
            //  2 5 8
            //  3 6 9

            Assert.AreEqual(1f, m[0][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(2f, m[0][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(3f, m[0][2], "Matrix does not implement column major semantics");
            Assert.AreEqual(4f, m[1][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(5f, m[1][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(6f, m[1][2], "Matrix does not implement column major semantics");
            Assert.AreEqual(7f, m[2][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(8f, m[2][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(9f, m[2][2], "Matrix does not implement column major semantics");

            Assert.AreEqual(1f, m[0, 0], "Matrix does not implement column major semantics");
            Assert.AreEqual(2f, m[0, 1], "Matrix does not implement column major semantics");
            Assert.AreEqual(3f, m[0, 2], "Matrix does not implement column major semantics");
            Assert.AreEqual(4f, m[1, 0], "Matrix does not implement column major semantics");
            Assert.AreEqual(5f, m[1, 1], "Matrix does not implement column major semantics");
            Assert.AreEqual(6f, m[1, 2], "Matrix does not implement column major semantics");
            Assert.AreEqual(7f, m[2, 0], "Matrix does not implement column major semantics");
            Assert.AreEqual(8f, m[2, 1], "Matrix does not implement column major semantics");
            Assert.AreEqual(9f, m[2, 2], "Matrix does not implement column major semantics");

            Assert.AreEqual(new vec3(1f, 2f, 3f), m[0], "Matrix does not implement column major semantics");
            Assert.AreEqual(new vec3(4f, 5f, 6f), m[1], "Matrix does not implement column major semantics");
            Assert.AreEqual(new vec3(7f, 8f, 9f), m[2], "Matrix does not implement column major semantics");
        }

        [Test]
        public void CanMultiplyByVector()
        {
            var m = new mat3(new[]
            {
                new vec3(1f, 2f, 3f),
                new vec3(4f, 5f, 6f),
                new vec3(7f, 8f, 9f),
            });
            var v = new vec3(10f, 11f, 12f);

            //  1  4  7   10   10 + 44 + 84    138
            //  2  5  8 * 11 = 20 + 55 + 96  = 171
            //  3  6  9   12   30 + 66 + 108   204

            Assert.AreEqual(new vec3(138f, 171f, 204f), m * v, "Rank 2 Matrix * Vector results are incorrect.");
        }
    }
}
