IF EXIST staging-console (
RMDIR /S /Q .\staging-console
)

MKDIR staging-console

SET TOOLS=.\tools
SET OUTPUTNAME=BenchmarkAnalyzer.Console.exe
SET ILMERGE=%TOOLS%\ILMerge.exe
SET RELEASE=..\..\BenchmarkAnalyzer.AppConsole\bin\x86\Release
SET INPUT=%RELEASE%\BenchmarkAnalyzer.AppConsole.exe
SET INPUT=%INPUT% %RELEASE%\BenchmarkAnalyzer.Resources.dll
SET INPUT=%INPUT% %RELEASE%\BenchmarkAnalyzer.ServiceInterface.dll
SET INPUT=%INPUT% %RELEASE%\BenchmarkAnalyzer.ServiceModel.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Text.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Client.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Common.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Interfaces.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.OrmLite.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.OrmLite.Sqlite.Windows.dll
SET INPUT=%INPUT% %RELEASE%\System.Data.SQLite.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Razor.dll
SET INPUT=%INPUT% %RELEASE%\System.Web.Razor.dll
SET INPUT=%INPUT% %RELEASE%\Ionic.Zip.dll

%ILMERGE% /target:exe /targetplatform:v4,"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5" /out:staging-console\%OUTPUTNAME% /ndebug %INPUT% 

COPY %RELEASE%\x86\SQLite.Interop.dll .\staging-console
COPY %RELEASE%\server.labels .\staging-console
COPY %RELEASE%\test.labels .\staging-console
COPY "%RELEASE%\Database Performance in ASP.NET.zip" .\staging-console
COPY %RELEASE%\BenchmarkAnalyzer.AppConsole.exe.config .\staging-console\%OUTPUTNAME%.config

IF EXIST BenchmarkAnalyzer-console.7z (
del BenchmarkAnalyzer-console.7z
)

IF EXIST BenchmarkAnalyzer-console.exe (
del BenchmarkAnalyzer-console.exe
)

cd tools && 7za a ..\BenchmarkAnalyzer-console.7z ..\staging-console\* && cd..
copy /b .\tools\7zsd_All.sfx + config-console.txt + BenchmarkAnalyzer-console.7z BenchmarkAnalyzer-console.exe