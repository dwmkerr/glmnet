using System;

namespace GlmNet 
{
	public static class glm
	{
		//	TODO: document and unit test.
		public static mat4 perspective(float fovy, float aspect, float zNear, float zFar)
		{
			//	Important: fovy must be in radians.

			float tanHalfFovy = (float)Math.Tan(fovy / 2.0f);

			mat4 result = mat4.identity();
            var a = result[0];
            var b = a[0];
			result[0,0] = 1.0f / (aspect * tanHalfFovy);
			result[1,1] = 1.0f / (tanHalfFovy);
			result[2,2] = - (zFar + zNear) / (zFar - zNear);
			result[2,3] = - 1.0f;
			result[3,2] = - (2.0f * zFar * zNear) / (zFar - zNear);
			return result;
		}

		public static mat4 translate(mat4 m, vec3 v)
		{
			mat4 result = m;
			result[3] = m[0] * v[0] + m[1] * v[1] + m[2] * v[2] + m[3];
			return result;
		}

		public static mat4 scale(mat4 m, vec3 v)
		{
			mat4 result = m;
			result[0] = m[0] * v[0];
			result[1] = m[1] * v[1];
			result[2] = m[2] * v[2];
			result[3] = m[3];
			return result;
		}
	}

}