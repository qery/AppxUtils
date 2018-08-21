@echo off

set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319

echo ===== Cleanup =====
del /Q Release\*.*

echo.
echo ===== Building =====
call %MSBuildDir%\msbuild AppxUtils.sln /maxcpucount:4 /nologo /verbosity:minimal /t:build /p:Configuration=Release /p:TargetFrameworkVersion=v4.0 /p:OutputPath=..\Release\ /p:DebugSymbols=false /p:DebugType=None /p:AllowedReferenceRelatedFileExtensions=none /p:GenerateDocumentation=true /p:Optimize=true
