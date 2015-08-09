IF EXIST staging-console (
RMDIR /S /Q .\staging-console
)

MKDIR staging-console

SET TOOLS=.\tools
SET OUTPUTNAME=React_Chat_Gap.Console.exe
SET ILMERGE=%TOOLS%\ILMerge.exe
SET RELEASE=..\..\React_Chat_Gap.AppConsole\bin\x86\Release
SET INPUT=%RELEASE%\React_Chat_Gap.AppConsole.exe
SET INPUT=%INPUT% %RELEASE%\React_Chat_Gap.Resources.dll
SET INPUT=%INPUT% %RELEASE%\React_Chat_Gap.ServiceInterface.dll
SET INPUT=%INPUT% %RELEASE%\React_Chat_Gap.ServiceModel.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Text.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Client.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Common.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Interfaces.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.OrmLite.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Redis.dll
SET INPUT=%INPUT% %RELEASE%\ServiceStack.Razor.dll
SET INPUT=%INPUT% %RELEASE%\System.Web.Razor.dll

%ILMERGE% /target:exe /targetplatform:v4,"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5" /out:staging-console\%OUTPUTNAME% /ndebug %INPUT% 

IF EXIST React_Chat_Gap-console.7z (
del React_Chat_Gap-console.7z
)

IF EXIST React_Chat_Gap-console.exe (
del React_Chat_Gap-console.exe
)

cd tools && 7za a ..\React_Chat_Gap-console.7z ..\staging-console\* && cd..
copy /b .\tools\7zsd_All.sfx + config-console.txt + React_Chat_Gap-console.7z React_Chat_Gap-console.exe