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
  class comparisionTests
  {
    [Test]
    public void CheckVectorReferenceEquality()
    {
      vec2 v2_1 = new vec2(1, 0);
      vec2 v2_2 = new vec2(1, 0);
      vec2 v2_3 = new vec2(0, 0);
      vec2 v2_1ref = v2_1;
      v2_1ref.y = 1;
      Assert.AreEqual(v2_1.GetHashCode(), v2_2.GetHashCode(), "Error Hashcodes are not the Same");
      Assert.AreNotEqual(v2_1.GetHashCode(), v2_1ref.GetHashCode(), "Error Hashcodes are the Same");
      Assert.AreNotEqual(v2_1.GetHashCode(), v2_3.GetHashCode(), "Error Hashcodes are the Same");

      vec3 v3_1 = new vec3(1, 0, 1);
      vec3 v3_2 = new vec3(1, 0, 1);
      vec3 v3_3 = new vec3(0, 0, 1);
      vec3 v3_1ref = v3_1;
      v3_1ref.y = 1;

      Assert.AreEqual(v3_1.GetHashCode(), v3_2.GetHashCode(), "Error Hashcodes are not the Same");
      Assert.AreNotEqual(v3_1.GetHashCode(), v3_1ref.GetHashCode(), "Error Hashcodes are the Same");
      Assert.AreNotEqual(v3_1.GetHashCode(), v3_3.GetHashCode(), "Error Hashcodes are the Same");

      vec4 v4_1 = new vec4(1, 0, 1, 1);
      vec4 v4_2 = new vec4(1, 0, 1, 1);
      vec4 v4_3 = new vec4(0, 0, 1, 1);
      vec4 v4_1ref = v4_1;
      v4_1ref.y = 1;

      Assert.AreEqual(v4_1.GetHashCode(), v4_2.GetHashCode(), "Error Hashcodes are not the Same");
      Assert.AreNotEqual(v4_1.GetHashCode(), v4_1ref.GetHashCode(), "Error Hashcodes are the Same");
      Assert.AreNotEqual(v4_1.GetHashCode(), v4_3.GetHashCode(), "Error Hashcodes are the Same");
    }

    [Test]
    public void CheckMatrixReferenceEquality()
    {
      vec2 v2_1 = new vec2(1, 0);
      vec2 v2_2 = new vec2(1, 0);
      vec2 v2_3 = new vec2(0, 0);
      mat2 m2_1 = new mat2(v2_1, v2_2);
      mat2 m2_2 = new mat2(v2_1, v2_2);
      mat2 m2_3 = new mat2(v2_1, v2_3);

      vec3 v3_1 = new vec3(1, 0, 1);
      vec3 v3_2 = new vec3(1, 0, 1);
      vec3 v3_3 = new vec3(0, 0, 1);
      mat3 m3_1 = new mat3(v3_1, v3_2,v3_2);
      mat3 m3_2 = new mat3(v3_1, v3_2, v3_2);
      mat3 m3_3 = new mat3(v3_1, v3_2, v3_3);


      vec4 v4_1 = new vec4(1, 0, 1, 1);
      vec4 v4_2 = new vec4(1, 0, 1, 1);
      vec4 v4_3 = new vec4(0, 0, 1, 1);
      mat4 m4_1 = new mat4(v4_1, v4_2, v4_2, v4_2);
      mat4 m4_2 = new mat4(v4_1, v4_2, v4_2, v4_2);
      mat4 m4_3 = new mat4(v4_1, v4_2, v4_2, v4_3);

      Assert.AreEqual(m2_1.GetHashCode(), m2_2.GetHashCode(), "Error Hashcodes are not the Same");
      Assert.AreNotEqual(m2_1.GetHashCode(), m2_3.GetHashCode(), "Error Hashcodes are the Same");
      Assert.AreEqual(m3_1.GetHashCode(), m3_2.GetHashCode(), "Error Hashcodes are not the Same");
      Assert.AreNotEqual(m3_1.GetHashCode(), m3_3.GetHashCode(), "Error Hashcodes are the Same");
      Assert.AreEqual(m4_1.GetHashCode(), m4_2.GetHashCode(), "Error Hashcodes are not the Same");
      Assert.AreNotEqual(m4_1.GetHashCode(), m4_3.GetHashCode(), "Error Hashcodes are the Same");
    }
   
  }
}
