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
    [Category("Matrices")]
    class MatrixTests
    {
        [Test]
        [Ignore("Blocked by bug #1.")]
        public void MatricesAreDeepCopied()
        {
            //  A matrix should be a struct, like in glm and C++. We should deep copy matrices, and when we do, 
            //  changing one should't change the other (test for issue #1).
            var m1 = mat2.identity();
            m1[0, 0] = 0.1f;
            m1[1, 0] = 0.2f;
            m1[1, 1] = 0.3f;
            m1[0, 1] = 0.4f;

            var m2 = m1;    //  todo: what do we do here? force a clone?

            m2[0, 0] = 1.1f;
            m2[1, 0] = 2.2f;
            m2[1, 1] = 3.3f;
            m2[0, 1] = 4.4f;

            Assert.AreEqual(m1[0, 0], 1.1f, "Deep copy is changing source object.");
            Assert.AreEqual(m1[1, 0], 0.2f, "Deep copy is changing source object.");
            Assert.AreEqual(m1[1, 1], 0.3f, "Deep copy is changing source object.");
            Assert.AreEqual(m1[0, 1], 0.4f, "Deep copy is changing source object.");
        }

        [Test]
        public void IdentityMatrixIsCorrect()
        {
            var m = mat2.identity();

            Assert.AreEqual(m[0, 0], 1f, "Incorrect identity matrix.");
            Assert.AreEqual(m[1, 0], 0f, "Incorrect identity matrix.");
            Assert.AreEqual(m[1, 1], 1f, "Incorrect identity matrix.");
            Assert.AreEqual(m[0, 1], 0f, "Incorrect identity matrix.");
        }
    }
}
