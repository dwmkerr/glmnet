using System;

namespace GlmNet 
{
	public struct vec2
	{
		public float x;
		public float y;

		public float this[int index]
		{
			get 
			{
				if(index == 0) return x;
				else if(index == 1) return y;
                else throw new Exception("Out of range.");
			}
			set 
			{
				if(index == 0) x = value;
                else if (index == 1) y = value;
                else throw new Exception("Out of range.");
			}
		}

		public vec2(float s)
		{
			x = y = s;
		}

		public vec2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		
		public static vec2 operator + (vec2 lhs, vec2 rhs)
		{
			return new vec2(lhs.x + rhs.x, lhs.y + rhs.y);
		}

        public static vec2 operator *(vec2 self, float s)
		{
			return new vec2(self.x * s, self.y * s);
		}
	}
}