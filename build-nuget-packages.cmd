@echo off
echo *** Make sure you have updated the assembly and nuspec to match the release version! ***
pause

call "%VS100COMNTOOLS%vsvars32.bat"
mkdir log\
mkdir lib\net40\

echo Debug build, running tests:
msbuild.exe /ToolsVersion:4.0 "swxben.helpers.sln" /p:configuration=Debug
call tests.bat

echo Release build:
msbuild.exe /ToolsVersion:4.0 "swxben.helpers.sln" /p:configuration=Release
utilities\nuget.exe pack swxben.helpers.nuspec
pause