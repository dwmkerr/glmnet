using System;
using System.Linq;

namespace GlmNet 
{
    /// <summary>
    /// Represents a 4x4 matrix.
    /// </summary>
	public struct mat4
	{
		public mat4(float scale)
		{
			cols = new vec4[4];
            cols[0] = new vec4(scale, 0.0f, 0.0f, 0.0f);
			cols[1] = new vec4(0.0f,	 scale, 0.0f,  0.0f);
			cols[2] = new vec4(0.0f,  0.0f,  scale, 0.0f);
			cols[3] = new vec4(0.0f,  0.0f,  0.0f,  scale);
		}

        public mat4(vec4[] cols)
        {
            this.cols = new vec4[4];
            this.cols[0] = cols[0];
            this.cols[1] = cols[1];
            this.cols[2] = cols[2];
            this.cols[3] = cols[3];
        }

		public vec4 this[int index]
		{
            get { return cols[index];}
            set { cols[index] = value;}
		}

        public float this[int index, int index2]
        {
            get { return cols[index][index2]; }
            set { cols[index][index2] = value; }
        }

        public static mat4 identity()
        {
            return new mat4
            {
                cols = new vec4[] 
                {
                    new vec4(1,0,0,0),
                    new vec4(0,1,0,0),
                    new vec4(0,0,1,0),
                    new vec4(0,0,0,1)
                }
            };
        }

        public float[] to_array()
        {
            return cols.SelectMany(v => v.to_array()).ToArray();
        }

        public mat3 to_mat3()
        {
            return new mat3(new[] {
			new vec3(cols[0][0], cols[0][1], cols[0][2]),
			new vec3(cols[1][0], cols[1][1], cols[1][2]),
			new vec3(cols[2][0], cols[2][1], cols[2][2])});
        }

        private vec4[] cols;

        public static mat4 operator * (mat4 lhs, mat4 rhs)
        {
            return new mat4( new [] {
			lhs[0][0] * rhs[0] + lhs[1][0] * rhs[1] + lhs[2][0] * rhs[2] + lhs[3][0] * rhs[3],
			lhs[0][1] * rhs[0] + lhs[1][1] * rhs[1] + lhs[2][1] * rhs[2] + lhs[3][1] * rhs[3],
			lhs[0][2] * rhs[0] + lhs[1][2] * rhs[1] + lhs[2][2] * rhs[2] + lhs[3][2] * rhs[3],
			lhs[0][3] * rhs[0] + lhs[1][3] * rhs[1] + lhs[2][3] * rhs[2] + lhs[3][3] * rhs[3]});
        }
	}
}