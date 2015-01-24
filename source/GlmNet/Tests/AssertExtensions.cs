using GlmNet;
using NUnit.Framework;

namespace Tests
{
    internal static class AssertExtensions
    {
        public static void AreVectorsEqual(vec3 expected, vec3 actual, float delta)
        {
            Assert.AreEqual(expected.x, actual.x, delta, "Vector X component is incorrect.");
            Assert.AreEqual(expected.y, actual.y, delta, "Vector Y component is incorrect.");
            Assert.AreEqual(expected.z, actual.z, delta, "Vector Z component is incorrect.");
        }
    }
}