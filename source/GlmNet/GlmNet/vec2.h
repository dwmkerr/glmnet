#pragma once

#include "glm\glm.hpp"

using namespace System;

namespace GlmNet 
{

	public ref struct vec2
	{
	public:
		float x;
		float y;

		float% operator[] (int index)
		{
			if(index == 0) return x;
			if(index == 1) return y;
			throw gcnew Exception("Invalid index on vec2");
		}
				
		vec2()
		{
			x = y = 0;
		}

		vec2(float x, float y)
		{
			vec2::x = x;
			vec2::y = y;
		}
	
		vec2(const vec2% rhs)
		{
			x = rhs.x;
			y = rhs.y;
		}

	};

}