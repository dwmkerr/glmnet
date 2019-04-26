# GlmNet

[![Nuget Badge](https://www.nuget.org/packages/GlmNet)](https://img.shields.io/nuget/v/GlmNet.svg)] [![Build status](https://ci.appveyor.com/api/projects/status/j2ymme2a28idi535?svg=true)](https://ci.appveyor.com/project/dwmkerr/glmnet) [![codecov](https://codecov.io/gh/dwmkerr/glmnet/branch/master/graph/badge.svg)](https://codecov.io/gh/dwmkerr/glmnet) [![GuardRails badge](https://badges.production.guardrails.io/dwmkerr/glmnet.svg)](https://www.guardrails.io)

GlmNet is a .NET version of the excellent [OpenGL Mathematics library (GLM)](http://glm.g-truc.net/).

The [OpenGL Mathematics Library](http://glm.g-truc.net/) is open source, licensed under the MIT license. I would like to thank [Christophe Riccio](http://www.g-truc.net/) for his permission to wrap the library.


<!-- vim-markdown-toc GFM -->

* [Development Status](#development-status)
* [Installation](#installation)
* [Usage](#usage)
* [Fundamentals](#fundamentals)
    * [Column Major Matrices](#column-major-matrices)
    * [Matrix Initialisation](#matrix-initialisation)
* [Code Structure](#code-structure)
* [API / Supported Features](#api--supported-features)
    * [GLM Core](#glm-core)
        * [Angle and Trigonometry Functions](#angle-and-trigonometry-functions)
        * [Geometric Functions](#geometric-functions)
        * [Matrix Functions](#matrix-functions)
    * [GTC Extensions (Stable)](#gtc-extensions-stable)
        * [GLM_GTC_matrix_transform](#glm_gtc_matrix_transform)
* [Developer Guide](#developer-guide)
    * [Building & Testing](#building--testing)
    * [CI/CD](#cicd)
    * [Releasing](#releasing)

<!-- vim-markdown-toc -->

## Development Status

Important: I am developing GlmNet as I need it - so there are very few advanced features from GLM ported over yet. Please do feel free to fork the code and add the features as you need them - if you create pull requests I'll merge them into the main branch.

## Installation

Install it with Nuget:

```
PM> Install-Package GlmNet
```

That's all there is to it!

## Usage 

GlmNet attempts to be as syntactically similar to GLM as possible. Examples are:

```cs
mat4 projectionMatrix = glm.perspective(rads, (float)Width / (float)Height, 0.1f, 100.0f);
mat4 viewMatrix = glm.translate(new mat4(1.0f), new vec3(0.0f, 0.0f, -5.0f));
mat4 modelMatrix = glm.scale(new mat4(1.0f), new vec3(0.5f));
```

## Fundamentals

### Column Major Matrices

GlmNet matrices are **Column Major**. This is because GLM attempts to mimic GLSL as closely as possible.

```
    | a b c |
    | d e f | = |M|
    | g h i |
```

This means M[0] gives column 0, i.e:

```
    | a |
    | d |
    | g |
```

M[1][2] or M[1,2] gives column 1, row 2, i.e:

```
    |h|
```

Column major matrices are used in OpenGL, row major in DirectX. Many C++ libraries are row major, be aware that GlmNet is column major. This means that as OpenGL vectors are typically columns, you multiply in the order matrix * vector:

```
    a = m * v
```

Rather than `v * m`.

### Matrix Initialisation

Matrices are NOT initialised to the identity. Use the `identity` function.
All types are based on floats.
Matrix elements are references as multidimensional arrays when you want to change them, e.g:

```cs
// Get data from matrices like this:
var element = matrix[1][2];

// ..or this..
var element = matrix[1,2];

// But SET data in a matrix like this:
matrix[1,2] = element;
```

All angles in GlmNet are expected to be in radians - no conversion to or from degrees is ever done.


## Code Structure

glm - A copy of the latest version of the OpenGL Mathematics library.
source - The source code for GlmNet.

## API / Supported Features

### GLM Core

 * Vectors: `vec2`, `vec3`, `vec4`
 * Matrices: `mat2`, `mat3`, `mat4`
 * Transformations: `scale`, `rotate`, `translate`
 * Projections: `perspective`, `frustum`
 * Matrix * Matrix
 * Matrix * Vector

#### Angle and Trigonometry Functions

 * `acos`
 * `acosh`
 * `asin`
 * `asinh`
 * `atan`
 * `atanh`
 * `cos`
 * `cosh`
 * `degrees`
 * `radians`
 * `sin`
 * `sinh`
 * `tan`
 * `tanh`

#### Geometric Functions

* `dot`
* `cross`
* `normalize`

Not Implemented

* `distance`
* `faceforward`
* `length`
* `reflect`
* `refract` 

#### Matrix Functions

 * `inverse`

Not implemented 

 * `determinant`
 * `matrixCompMult`
 * `outerProduct`
 * `transpose_type`

### GTC Extensions (Stable)

#### GLM_GTC_matrix_transform

All functions are supported. Angles are always in radians.

 * `frustum`
 * `infinitePerspective`
 * `lookAt`
 * `ortho`
 * `perspective`
 * `perspectiveFov`
 * `pickMatrix`
 * `project`
 * `rotate`
 * `scale`
 * `translate`
 * `tweakedInfinitePerspective`
 * `unProject`

## Developer Guide

### Building & Testing

As long as the correct components have be installed for Visual Studio, you should be able to just open the main `./source/GlmNet/GlmtNet.sln` solution to build, test and run any of the code or samples.

You can also use the following scripts to run the processes:

| Script         | Notes                                                                                                                                |
|----------------|--------------------------------------------------------------------------------------------------------------------------------------|
| `config.ps1`   | Ensure your machine can run builds by installing necessary components such as `nunit`. Should only need to be run once.              |
| `build.ps1`    | Build all solutions. |
| `test.ps1`     | Run all tests. |
| `coverage.ps1` | Create a coverage report for the main `GlmNet` project. Reports are written to `./artifacts/coverage` |

These scripts will generate various artifacts which may be useful to review:

```
artifacts\
  \tests                  # NUnit Test Reports
  \coverage               # Coverage Reports
```

### CI/CD

To run the full pipeline, the build system should have the following environment variables set:

| Environment Variable | Usage                           |
|----------------------|---------------------------------|
| `CODECOV_TOKEN`      | The upload token for Codecov.io |

### Releasing

Update the solution version in the AssemblyInfo. Create a git tag which matches this new version. Then push:

```sh
git push --follow-tags
```

As long as the build succeeds, the presence of the tag will trigger the release.
