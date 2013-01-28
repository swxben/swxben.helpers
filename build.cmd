@echo off
call "%VS100COMNTOOLS%vsvars32.bat"
mkdir log
mkdir lib\net40
mkdir nupkg_archive

echo Debug build, running tests:
msbuild.exe /ToolsVersion:4.0 "swxben.helpers.sln" /p:configuration=Debug
call tests.bat

echo Release build:
msbuild.exe /ToolsVersion:4.0 "swxben.helpers.sln" /p:configuration=Release
.nuget\nuget.exe pack swxben.helpers.nuspec

echo *** Ready to upload to nuget.org ***
pause

for %%f in (*.nupkg) do (
	.nuget\nuget.exe push %%f
)

copy *.nupkg nupkg_archive\
del *.nupkg

pause

