#pragma once

#include "glm\glm.hpp"

#include "vec3.h"

using namespace System;

namespace GlmNet 
{

	public ref struct mat3
	{
	public:
		
		mat3()
		{
			value = gcnew array<vec3^>(3);
		}

		mat3(mat3^ mat3)
		{
			value = gcnew array<vec3^>(3);
			value[0] = gcnew vec3(*mat3->value[0]);
			value[1] = gcnew vec3(*mat3->value[1]);
			value[2] = gcnew vec3(*mat3->value[2]);
		}
		
		vec3^ operator[] (int index)
		{
			return value[index];
		}

	private:

		array<vec3^>^ value;
	};
}