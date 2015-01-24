# Useful paths.
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
$root = Split-Path $PSScriptRoot -Parent

# Applications we use.
$openCover = "$root\source\GlmNet\packages\OpenCover.4.5.3522\OpenCover.Console.exe"
$nUnitConsole = "$root\GlmNet\packages\NUnit.Runners.2.6.4\tools\nunit-console.exe"

. $openCover -target:"$nUnitConsole" -targetargs:"/nologo $glmNet /noshadow" -filter:"+[ProjToTest]ProjToTest*" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"_CodeCoverageResult.xml"

"..\..\..\packages\ReportGenerator.1.9.1.0\ReportGenerator.exe" "-reports:_CodeCoverageResult.xml" "-targetdir:_CodeCoverageReport"