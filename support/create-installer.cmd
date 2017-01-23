@echo off

set EXITCODE=1
SET MYDIR=%~dp0

rem Check for NSIS
IF EXIST "%ProgramFiles%\NSIS\makensis.exe" (
  set NSIS="%ProgramFiles%\NSIS\makensis.exe"
) ELSE IF EXIST "%ProgramFiles(x86)%\NSIS\makensis.exe" (
  set NSIS="%ProgramFiles(x86)%\NSIS\makensis.exe"
) ELSE GOTO NONSIS

rem Check for VC12
IF "%VS120COMNTOOLS%"=="" (
  set COMPILER12="%ProgramFiles%\Microsoft Visual Studio 12.0\Common7\IDE\devenv.com"
) ELSE IF EXIST "%VS120COMNTOOLS%\..\IDE\VCExpress.exe" (
  set COMPILER12="%VS120COMNTOOLS%\..\IDE\VCExpress.exe"
) ELSE IF EXIST "%VS120COMNTOOLS%\..\IDE\devenv.com" (
  set COMPILER12="%VS120COMNTOOLS%\..\IDE\devenv.com"
) ELSE GOTO NOSDK11

rmdir /s /q %MYDIR%..\build

cd "%MYDIR%..\project"

rem Skip to libCEC/x86 when we're running on win32
if "%PROCESSOR_ARCHITECTURE%"=="x86" if "%PROCESSOR_ARCHITEW6432%"=="" goto libcecx86

rem Compile libCEC and cec-client x64
echo. Cleaning libCEC (x64)
%COMPILER12% cec-dotnet.sln /Clean "Release|x64"
echo. Compiling libCEC (x64)
%COMPILER12% cec-dotnet.sln /Build "Release|x64"

:libcecx86
rem Compile libCEC and cec-client Win32
echo. Cleaning libCEC (x86)
%COMPILER12% cec-dotnet.sln /Clean "Release|x86"
echo. Compiling libCEC (x86)
%COMPILER12% cec-dotnet.sln /Build "Release|x86"

rem Calls signtool.exe and signs the DLLs with Pulse-Eight's code signing key
IF NOT EXIST "..\support\private\sign-binary.cmd" GOTO CREATEINSTALLER
echo. Signing all binaries
CALL ..\support\private\sign-binary.cmd %MYDIR%..\build\x86\CecSharpTester.exe
CALL ..\support\private\sign-binary.cmd %MYDIR%..\build\x86\cec-tray.exe
CALL ..\support\private\sign-binary.cmd %MYDIR%..\build\amd64\CecSharpTester.exe
CALL ..\support\private\sign-binary.cmd %MYDIR%..\build\amd64\cec-tray.exe

:CREATEINSTALLER
echo. Creating the installer
%NSIS% /V1 /X"SetCompressor /FINAL lzma" "cec-dotnet.nsi"

FOR /F "delims=" %%F IN ('dir /b /s "%MYDIR%..\build\libCEC.Net.exe" 2^>nul') DO SET INSTALLER=%%F
IF [%INSTALLER%] == [] GOTO :ERRORCREATINGINSTALLER

rem Sign the installer if sign-binary.cmd exists
IF EXIST "..\support\private\sign-binary.cmd" (
  echo. Signing the installer binaries
  CALL ..\support\private\sign-binary.cmd %INSTALLER%
)

echo. The installer can be found here: %INSTALLER%
set EXITCODE=0
GOTO EXIT

:NOSDK11
echo. Visual Studio 2012 was not found on your system.
GOTO EXIT

:NOSIS
echo. NSIS could not be found on your system.
GOTO EXIT

:ERRORCREATINGINSTALLER
echo. The installer could not be created. The most likely cause is that something went wrong while compiling.
GOTO RETURNEXIT

:EXIT
cd %MYDIR%

:RETURNEXIT
exit /b %EXITCODE%
pause