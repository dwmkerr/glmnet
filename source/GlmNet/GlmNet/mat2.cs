using System;
using System.Linq;

namespace GlmNet 
{
    /// <summary>
    /// Represents a 2x2 matrix.
    /// </summary>
	public struct mat2
	{
		public mat2(float scale)
		{
			cols = new vec2[4];
            cols[0] = new vec2(scale, 0.0f);
			cols[1] = new vec2(0.0f,	 scale);
		}

        public mat2(vec2[] cols)
        {
            this.cols = new vec2[2];
            this.cols[0] = cols[0];
            this.cols[1] = cols[1];
        }

		public vec2 this[int index]
		{
            get { return cols[index];}
            set { cols[index] = value; }
		}

        public float this[int index, int index2]
        {
            get { return cols[index][index2]; }
            set { cols[index][index2] = value; }
        }

        public static mat2 identity()
        {
            return new mat2
            {
                cols = new vec2[] 
                {
                    new vec2(1,0),
                    new vec2(0,1)
                }
            };
        }

        public float[] to_array()
        {
            return cols.SelectMany(v => v.to_array()).ToArray();
        }

        private vec2[] cols;
	}
}