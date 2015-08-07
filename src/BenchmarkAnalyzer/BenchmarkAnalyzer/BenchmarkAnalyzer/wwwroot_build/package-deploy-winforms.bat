IF EXIST staging-winforms\ (
RMDIR /S /Q .\staging-winforms
)

MKDIR staging-winforms

SET TOOLS=.\tools
SET RELEASE=..\..\BenchmarkAnalyzer.AppWinForms\bin\x86\Release
COPY %RELEASE%\BenchmarkAnalyzer.AppWinForms.exe .\staging-winforms
COPY %RELEASE%\CefSharp.BrowserSubprocess.exe .\staging-winforms
COPY %RELEASE%\BenchmarkAnalyzer.AppWinForms.exe.config .\staging-winforms
COPY "%RELEASE%\Database Performance in ASP.NET.zip" .\staging-winforms
ROBOCOPY "%RELEASE%" ".\staging-winforms" *.dll *.pak *.dat /E

IF EXIST BenchmarkAnalyzer-winforms.7z (
del BenchmarkAnalyzer-winforms.7z
)

IF EXIST BenchmarkAnalyzer-winforms.exe (
del BenchmarkAnalyzer-winforms.exe
)

cd tools && 7za a ..\BenchmarkAnalyzer-winforms.7z ..\staging-winforms\* && cd..
copy /b .\tools\7zsd_All.sfx + config-winforms.txt + BenchmarkAnalyzer-winforms.7z BenchmarkAnalyzer-winforms.exe