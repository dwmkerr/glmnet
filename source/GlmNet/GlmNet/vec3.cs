using System;

namespace GlmNet 
{
	public struct vec3
	{
		public float x;
		public float y;
		public float z;

		public float this[int index]
		{
			get 
			{
				if(index == 0) return x;
				else if(index == 1) return y;
				else if(index == 2) return z;
                else throw new Exception("Out of range.");
			}
			set 
			{
				if(index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
			}
		}

		public vec3(float s)
		{
			x = y = z = s;
		}

		public vec3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
            this.z = z;
		}
		
		public static vec3 operator + (vec3 lhs, vec3 rhs)
		{
			return new vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}

        public static vec3 operator *(vec3 self, float s)
		{
			return new vec3(self.x * s, self.y * s, self.z * s);
		}
	}
}