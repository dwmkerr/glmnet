using System;

namespace GlmNet 
{
    /// <summary>
    /// The glm class contains static functions as exposed in the glm namespace of the 
    /// GLM library. The lowercase naming is to keep the code as consistent as possible
    /// with the real GLM.
    /// </summary>
	public static class glm
	{
        /// <summary>
        /// Creates a perspective transformation matrix.
        /// </summary>
        /// <param name="fovy">The field of view angle, in radians.</param>
        /// <param name="aspect">The aspect ratio.</param>
        /// <param name="zNear">The near depth clipping plane.</param>
        /// <param name="zFar">The far depth clipping plane.</param>
        /// <returns>A <see cref="mat4"/> that contains the projection matrix for the perspective transformation.</returns>
		public static mat4 perspective(float fovy, float aspect, float zNear, float zFar)
		{
			var tanHalfFovy = (float)Math.Tan(fovy / 2.0f);

            var result = mat4.identity();
			result[0,0] = 1.0f / (aspect * tanHalfFovy);
			result[1,1] = 1.0f / (tanHalfFovy);
			result[2,2] = - (zFar + zNear) / (zFar - zNear);
			result[2,3] = - 1.0f;
			result[3,2] = - (2.0f * zFar * zNear) / (zFar - zNear);
			return result;
		}

        /// <summary>
        /// Creates a frustrum projection matrix.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="nearVal">The near val.</param>
        /// <param name="farVal">The far val.</param>
        /// <returns></returns>
        public static mat4 frustum(float left, float right, float bottom, float top, float nearVal, float farVal)
        {
            var result = mat4.identity();
            result[0, 0] = (2.0f*nearVal)/(right - left);
            result[1, 1] = (2.0f*nearVal)/(top - bottom);
            result[2, 0] = (right + left)/(right - left);
            result[2, 1] = (top + bottom)/(top - bottom);
            result[2, 2] = -(farVal + nearVal)/(farVal - nearVal);
            result[2, 3] = -1.0f;
            result[3, 2] = -(2.0f*farVal*nearVal)/(farVal - nearVal);
            return result;
        }

        /// <summary>
        /// Applies a translation transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="m">The matrix to transform.</param>
        /// <param name="v">The vector to translate by.</param>
        /// <returns><paramref name="m"/> translated by <paramref name="v"/>.</returns>
		public static mat4 translate(mat4 m, vec3 v)
		{
			mat4 result = m;
			result[3] = m[0] * v[0] + m[1] * v[1] + m[2] * v[2] + m[3];
			return result;
		}

        /// <summary>
        /// Applies a scale transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="m">The matrix to transform.</param>
        /// <param name="v">The vector to scale by.</param>
        /// <returns><paramref name="m"/> scaled by <paramref name="v"/>.</returns>
		public static mat4 scale(mat4 m, vec3 v)
		{
			mat4 result = m;
			result[0] = m[0] * v[0];
			result[1] = m[1] * v[1];
			result[2] = m[2] * v[2];
			result[3] = m[3];
			return result;
		}

        #region Cross Product

        public static vec3 cross(vec3 lhs, vec3 rhs)
        {
            return new vec3(
                lhs.y * rhs.z - rhs.y * lhs.z,
			    lhs.z * rhs.x - rhs.z * lhs.x,
			    lhs.x * rhs.y - rhs.x * lhs.y);
        }

        #endregion

        #region Rotation

        public static mat4 rotate(mat4 m, float angle, vec3 v)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);

		    vec3 axis = normalize(v);
		    vec3 temp = (1.0f - c) * axis;

            mat4 rotate = mat4.identity();
		    rotate[0,0] = c + temp[0] * axis[0];
		    rotate[0,1] = 0 + temp[0] * axis[1] + s * axis[2];
		    rotate[0,2] = 0 + temp[0] * axis[2] - s * axis[1];
                    
		    rotate[1,0] = 0 + temp[1] * axis[0] - s * axis[2];
		    rotate[1,1] = c + temp[1] * axis[1];
		    rotate[1,2] = 0 + temp[1] * axis[2] + s * axis[0];
                    
		    rotate[2,0] = 0 + temp[2] * axis[0] + s * axis[1];
		    rotate[2,1] = 0 + temp[2] * axis[1] - s * axis[0];
		    rotate[2,2] = c + temp[2] * axis[2];

		    mat4 result = mat4.identity();
            result[0] = m[0] * rotate[0][0] + m[1] * rotate[0][1] + m[2] * rotate[0][2];
		    result[1] = m[0] * rotate[1][0] + m[1] * rotate[1][1] + m[2] * rotate[1][2];
		    result[2] = m[0] * rotate[2][0] + m[1] * rotate[2][1] + m[2] * rotate[2][2];
		    result[3] = m[3];
		    return result;
	    }

        #endregion

        #region Normalize

        public static vec2 normalize(vec2 v)
        {
            float sqr = v.x * v.x + v.y * v.y;
            return v * (1.0f / (float)Math.Sqrt(sqr));
        }

        public static vec3 normalize(vec3 v)
        {
            float sqr = v.x * v.x + v.y * v.y + v.z * v.z;
            return v * (1.0f / (float)Math.Sqrt(sqr));
        }

        public static vec4 normalize(vec4 v)
        {
            float sqr = v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w;
            return v * (1.0f / (float)Math.Sqrt(sqr));
        }

        #endregion
    }

}