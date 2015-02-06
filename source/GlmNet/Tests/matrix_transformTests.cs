using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlmNet;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    /// <summary>
    /// General tests for all matrix types.
    /// </summary>
    [TestFixture]
    [Category("matrix_transform")]
    class matrix_transformTests
    {
        [Test]
        public void CanCreateLookAtProjection()
        {
            var eye = new vec3(4f, 4f, 4f);
            var centre = new vec3(0f, 0f, 0f);
            var up = new vec3(0f, 1f, 0f);

            var result = glm.lookAt(eye, centre, up);
        }
    }
}
