GlmNet
======

GlmNet is a .NET version of the excellent [OpenGL Mathematics library (GLM)](http://glm.g-truc.net/).

The [OpenGL Mathematics Library](http://glm.g-truc.net/) is open source, licensed under the MIT license. I would like to thank [Christophe Riccio](http://www.g-truc.net/) for his permission to wrap the library.

Important: I am developing GlmNet as I need it - so there are very few advanced features from GLM ported over yet. Please do feel free to fork the code and add the features as you need them - if you create pull requests I'll merge them into the main branch.

Install it with Nuget:

````
PM> Install-Package GlmNet
````

That's all there is to it!

Usage
-----

GlmNet attempts to be as syntactically similar to GLM as possible. Examples are:

````csharp
mat4 projectionMatrix = glm.perspective(rads, (float)Width / (float)Height, 0.1f, 100.0f);
mat4 viewMatrix = glm.translate(new mat4(1.0f), new vec3(0.0f, 0.0f, -5.0f));
mat4 modelMatrix = glm.scale(new mat4(1.0f), new vec3(0.5f));
````

Fundamentals
------------

Matrices are NOT initialised to the identity. Use the ````identity```` function.
All types are based on floats.
Matrice elements are references as multidimensional arrays when you want to change them, e.g:

````
// Get data from matrices like this:
var element = matrix[1][2];
// ..or this..
var element = matrix[1,2];

// But SET data in a matrix like this:
matrix[1,2] = element;
````

All angles in GlmNet are expected to be in radians - no conversion to or from degrees is ever done.


Structure
---------

glm - A copy of the latest version of the OpenGL Mathematics library.
source - The sourcecode for GLMNET.

Supported Functionality
-----------------------

 * Vectors: ``vec2``, ``vec3``, ``vec4``
 * Matrices: ``mat2``, ``mat3``, ``mat4``
 * Transformations: ``scale``, ``rotate``, ``translate``
 * Projections: ``perspective``, ``frustum``
