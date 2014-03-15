#pragma once

#include "glm\glm.hpp"

#include "vec2.h"

using namespace System;

namespace GlmNet 
{

	public ref struct mat2
	{
	public:
		
		mat2()
		{
			value = gcnew array<vec2^>(2);
		}

		mat2(mat2^ mat2)
		{
			value = gcnew array<vec2^>(2);
			value[0] = gcnew vec2(*mat2->value[0]);
			value[1] = gcnew vec2(*mat2->value[1]);
		}
		
		vec2^ operator[] (int index)
		{
			return value[index];
		}

	private:

		array<vec2^>^ value;
	};
}