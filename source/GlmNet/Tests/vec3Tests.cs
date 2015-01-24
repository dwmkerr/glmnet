using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlmNet;
using NUnit.Framework;

namespace Tests
{
    [TestFixture(Category = "Rank 2 Vectors")]
    class vec3Tests
    {
        [Test]
        public void CanPerformVectorSubtraction()
        {
            var v1 = new vec3(1.0f, 2.0f, 3.0f);
            var v2 = new vec3(0.5f, 5.0f, -3.0f);
            Assert.AreEqual(
                new vec3(0.5f, -3.0f, 6.0f),
                v1 - v2);
        }
    }
}
