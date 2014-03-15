#pragma once

#include "glm\glm.hpp"

using namespace System;

namespace GlmNet 
{
	public ref struct vec4
	{
	public:
		float x;
		float y;
		float z;
		float w;

		float% operator[] (int index)
		{
			if(index == 0) return x;
			if(index == 1) return y;
			if(index == 2) return z;
			if(index == 3) return w;
			throw gcnew Exception("Invalid index on vec4");
		}

		vec4()
		{
			x = y = z = w = 0;
		}

		vec4(float x, float y, float z, float w)
		{
			vec4::x = x;
			vec4::y = y;
			vec4::z = z;
			vec4::w = w;
		}
	
		vec4(const vec4% rhs)
		{
			x = rhs.x;
			y = rhs.y;
			z = rhs.z;
			w = rhs.w;
		}

	};

}