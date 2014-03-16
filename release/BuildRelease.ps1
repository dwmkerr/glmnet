# IMPORTANT: Make sure that the path to msbuild is correct!  
$msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
if ((Test-Path $msbuild) -eq $false) {
    Write-Host "Cannot find msbuild at '$msbuild'."
    Break
}

# Load useful functions.
. .\Resources\PowershellFunctions.ps1

# Keep track of the 'release' folder location - it's the root of everything else.
# We can also build paths to the key locations we'll use.
$scriptParentPath = Split-Path -parent $MyInvocation.MyCommand.Definition
$folderReleaseRoot = $scriptParentPath
$folderSourceRoot = Split-Path -parent $folderReleaseRoot
$folderSolutionsRoot = Join-Path $folderSourceRoot "source\GlmNet"
$folderNuspecRoot = Join-Path $folderSourceRoot "release\nuspec"

# Part 1 - Build the main libraries.
Write-Host "Preparing to build the core library..."
$solutionCoreLibraries = Join-Path $folderSolutionsRoot "GlmNet.sln"
. $msbuild $solutionCoreLibraries /p:Configuration=Release /verbosity:minimal

# Part 2 - Get the version number of the core library, use this to build the destination release folder.
$folderBinaries = Join-Path $folderSolutionsRoot "GlmNet\bin\Release"
$releaseVersion = [Reflection.Assembly]::LoadFile((Join-Path $folderBinaries "GlmNet.dll")).GetName().Version
Write-Host "Built Core Library. Release Version: $releaseVersion"

# Part 3 - Copy the core library to the release.
$folderRelease = Join-Path $folderReleaseRoot $releaseVersion
$folderReleaseCore = Join-Path $folderRelease "Core"
EnsureEmptyFolderExists($folderReleaseCore)
CopyItems (Join-Path $folderBinaries "*.*") $folderReleaseCore

# Part 4 - Build the Nuget Package
Write-Host "Preparing to build the Nuget Package..."
$folderReleasePackage = Join-Path $folderRelease "Package"
EnsureEmptyFolderExists($folderReleasePackage)
$nuget = Join-Path $scriptParentPath "Resources\nuget.exe"

CopyItems (Join-Path $folderReleaseCore "*.*") (Join-Path $folderNuspecRoot "GlmNet\lib\net40")
. $nuget pack (Join-Path $folderNuspecRoot "GlmNet\GlmNet.nuspec") -Version $releaseVersion -OutputDirectory $folderReleasePackage

# We're done!
Write-Host "Successfully built version: $releaseVersion"