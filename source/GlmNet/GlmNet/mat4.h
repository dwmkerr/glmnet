#pragma once

#include "glm\glm.hpp"

#include "vec4.h"

using namespace System;

namespace GlmNet 
{

	public ref struct mat4
	{
	public:

		mat4()
		{
			value = gcnew array<vec4^>(4);
			value[0] = gcnew vec4();
			value[1] = gcnew vec4();
			value[2] = gcnew vec4();
			value[3] = gcnew vec4();
		}

		mat4(mat4^ mat4)
		{
			value = gcnew array<vec4^>(4);
			value[0] = gcnew vec4(*mat4->value[0]);
			value[1] = gcnew vec4(*mat4->value[1]);
			value[2] = gcnew vec4(*mat4->value[2]);
			value[3] = gcnew vec4(*mat4->value[3]);
		}

		vec4^ operator[] (int index)
		{
			return value[index];
		}

	private:

		array<vec4^>^ value;
	};
}