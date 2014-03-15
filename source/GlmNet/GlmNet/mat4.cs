using System;

namespace GlmNet 
{

	public struct mat4
	{
		public mat4(float scale)
		{
			val = new vec4[4];
            val[0] = new vec4(scale, 0.0f, 0.0f, 0.0f);
			val[1] = new vec4(0.0f,	 scale, 0.0f,  0.0f);
			val[2] = new vec4(0.0f,  0.0f,  scale, 0.0f);
			val[3] = new vec4(0.0f,  0.0f,  0.0f,  scale);
		}

		public vec4 this[int index]
		{
            get { return val[index];}
            set { val[index] = value;}
		}

        public float this[int index, int index2]
        {
            get { return val[index][index2]; }
            set { val[index][index2] = value; }
        }

        public static mat4 identity()
        {
            return new mat4
            {
                val = new vec4[] 
                {
                    new vec4(1,0,0,0),
                    new vec4(0,1,0,0),
                    new vec4(0,0,1,0),
                    new vec4(0,0,0,1)
                }
            };
        }

        private vec4[] val;
	}
}