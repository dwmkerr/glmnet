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
    [Category("Rank 4 Matrices")]
    class mat4Tests
    {
        [Test]
        public void MatrixIsColumnMajor()
        {
            //  A pretty critical test as this is fundamental.
            var m = new mat4(new [] {
                new vec4(1f, 2f, 3f, 4f),
                new vec4(5f, 6f, 7f, 8f),
                new vec4(9f, 10f, 11f, 12f), 
                new vec4(13f, 14f, 15f, 16f)
            });

            Assert.AreEqual(1f, m[0][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(2f, m[0][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(3f, m[0][2], "Matrix does not implement column major semantics");
            Assert.AreEqual(4f, m[0][3], "Matrix does not implement column major semantics");
            Assert.AreEqual(5f, m[1][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(6f, m[1][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(7f, m[1][2], "Matrix does not implement column major semantics");
            Assert.AreEqual(8f, m[1][3], "Matrix does not implement column major semantics");
            Assert.AreEqual(9f, m[2][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(10f, m[2][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(11f, m[2][2], "Matrix does not implement column major semantics");
            Assert.AreEqual(12f, m[2][3], "Matrix does not implement column major semantics");
            Assert.AreEqual(13f, m[3][0], "Matrix does not implement column major semantics");
            Assert.AreEqual(14f, m[3][1], "Matrix does not implement column major semantics");
            Assert.AreEqual(15f, m[3][2], "Matrix does not implement column major semantics");
            Assert.AreEqual(16f, m[3][3], "Matrix does not implement column major semantics");

            Assert.AreEqual(1f, m[0,0], "Matrix does not implement column major semantics");
            Assert.AreEqual(2f, m[0,1], "Matrix does not implement column major semantics");
            Assert.AreEqual(3f, m[0,2], "Matrix does not implement column major semantics");
            Assert.AreEqual(4f, m[0,3], "Matrix does not implement column major semantics");
            Assert.AreEqual(5f, m[1,0], "Matrix does not implement column major semantics");
            Assert.AreEqual(6f, m[1,1], "Matrix does not implement column major semantics");
            Assert.AreEqual(7f, m[1,2], "Matrix does not implement column major semantics");
            Assert.AreEqual(8f, m[1,3], "Matrix does not implement column major semantics");
            Assert.AreEqual(9f, m[2,0], "Matrix does not implement column major semantics");
            Assert.AreEqual(10f, m[2,1], "Matrix does not implement column major semantics");
            Assert.AreEqual(11f, m[2,2], "Matrix does not implement column major semantics");
            Assert.AreEqual(12f, m[2,3], "Matrix does not implement column major semantics");
            Assert.AreEqual(13f, m[3,0], "Matrix does not implement column major semantics");
            Assert.AreEqual(14f, m[3,1], "Matrix does not implement column major semantics");
            Assert.AreEqual(15f, m[3,2], "Matrix does not implement column major semantics");
            Assert.AreEqual(16f, m[3,3], "Matrix does not implement column major semantics");

            Assert.AreEqual(new vec4(1f, 2f, 3f, 4f), m[0], "Matrix does not implement column major semantics");
            Assert.AreEqual(new vec4(5f, 6f, 7f, 8f), m[1], "Matrix does not implement column major semantics");
            Assert.AreEqual(new vec4(9f, 10f, 11f, 12f), m[2], "Matrix does not implement column major semantics");
            Assert.AreEqual(new vec4(13f, 14f, 15f, 16f), m[3], "Matrix does not implement column major semantics");
        }

        [Test]
        public void CanMultiplyByVector()
        {
            var m = new mat4(new[] {
                new vec4(1f, 2f, 3f, 4f),
                new vec4(5f, 6f, 7f, 8f),
                new vec4(9f, 10f, 11f, 12f), 
                new vec4(13f, 14f, 15f, 16f)
            });
            var v = new vec4(17f, 18f, 19f, 20f);


            Assert.AreEqual(new vec4(538f, 612f, 686f, 760f), m * v, "Rank 2 Matrix * Vector results are incorrect.");
        }
    }
}
