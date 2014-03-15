#pragma once

#include "glm\glm.hpp"

using namespace System;

namespace GlmNet 
{

	public ref struct vec3
	{
	public:
		float x;
		float y;
		float z;

		float% operator[] (int index)
		{
			if(index == 0) return x;
			if(index == 1) return y;
			if(index == 2) return z;
			throw gcnew Exception("Invalid index on vec3");
		}
		
		vec3()
		{
			x = y = z = 0;
		}

		vec3(float x, float y, float z)
		{
			vec3::x = x;
			vec3::y = y;
			vec3::z = z;
		}
	
		vec3(const vec3% rhs)
		{
			x = rhs.x;
			y = rhs.y;
			z = rhs.z;
		}

	};

}