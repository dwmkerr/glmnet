using System;
using System.Linq;

namespace GlmNet 
{
    /// <summary>
    /// Represents a 3x3 matrix.
    /// </summary>
	public struct mat3
	{
		public mat3(float scale)
		{
			cols = new vec3[4];
            cols[0] = new vec3(scale, 0.0f, 0.0f);
			cols[1] = new vec3(0.0f,	 scale, 0.0f);
			cols[2] = new vec3(0.0f,  0.0f,  scale);
		}

        public mat3(vec3[] cols)
        {
            this.cols = new vec3[3];
            this.cols[0] = cols[0];
            this.cols[1] = cols[1];
            this.cols[2] = cols[2];
        }

		public vec3 this[int index]
		{
            get { return cols[index];}
            set { cols[index] = value;}
		}

        public float this[int index, int index2]
        {
            get { return cols[index][index2]; }
            set { cols[index][index2] = value; }
        }

        public static mat3 identity()
        {
            return new mat3
            {
                cols = new vec3[] 
                {
                    new vec3(1,0,0),
                    new vec3(0,1,0),
                    new vec3(0,0,1)
                }
            };
        }

        public float[] to_array()
        {
            return cols.SelectMany(v => v.to_array()).ToArray();
        }

        private vec3[] cols;
	}
}