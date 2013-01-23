@echo off
.\packages\NUnit.Runners.2.6.2\tools\nunit-console.exe .\src\swxben.helpers.tests\bin\Debug\swxben.helpers.tests.dll
del /Q TestResult.xml
pause