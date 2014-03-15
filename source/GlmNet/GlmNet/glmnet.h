#pragma once

#include "mat4.h"
#include "glm\gtc\matrix_transform.hpp"

using namespace System;

namespace GlmNet 
{
	public ref class glm abstract sealed
	{
	public:

		//	TODO: document and unit test.
		static mat4^ perspective(float fovy, float aspect, float zNear, float zFar)
		{
			//	Important: fovy must be in radians.

			float tanHalfFovy = tan(fovy / 2.0f);

			mat4^ result = gcnew mat4();
			result[0][0] = 1.0f / (aspect * tanHalfFovy);
			result[1][1] = 1.0f / (tanHalfFovy);
			result[2][2] = - (zFar + zNear) / (zFar - zNear);
			result[2][3] = - 1.0f;
			result[3][2] = - (2.0f * zFar * zNear) / (zFar - zNear);
			return result;
		}


	};

}

/*
template <typename valType>
	GLM_FUNC_QUALIFIER detail::tmat4x4<valType, defaultp> perspective
	(
		valType const & fovy,
		valType const & aspect,
		valType const & zNear,
		valType const & zFar
	)
	{
		assert(aspect != valType(0));
		assert(zFar != zNear);

#ifdef GLM_FORCE_RADIANS
		valType const rad = fovy;
#else
#		pragma message("GLM: perspective function taking degrees as a parameter is deprecated. #define GLM_FORCE_RADIANS before including GLM headers to remove this message.")
		valType const rad = glm::radians(fovy);
#endif

		valType tanHalfFovy = tan(rad / valType(2));

		detail::tmat4x4<valType, defaultp> Result(valType(0));
		Result[0][0] = valType(1) / (aspect * tanHalfFovy);
		Result[1][1] = valType(1) / (tanHalfFovy);
		Result[2][2] = - (zFar + zNear) / (zFar - zNear);
		Result[2][3] = - valType(1);
		Result[3][2] = - (valType(2) * zFar * zNear) / (zFar - zNear);
		return Result;
	}*/