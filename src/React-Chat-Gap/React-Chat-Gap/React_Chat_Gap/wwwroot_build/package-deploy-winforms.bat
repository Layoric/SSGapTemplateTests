IF EXIST staging-winforms\ (
RMDIR /S /Q .\staging-winforms
)

MKDIR staging-winforms

SET TOOLS=.\tools
SET RELEASE=..\..\React_Chat_Gap.AppWinForms\bin\x86\Release
COPY %RELEASE%\React_Chat_Gap.AppWinForms.exe .\staging-winforms
COPY %RELEASE%\CefSharp.BrowserSubprocess.exe .\staging-winforms
ROBOCOPY "%RELEASE%" ".\staging-winforms" *.dll *.pak *.dat /E

IF EXIST React_Chat_Gap-winforms.7z (
del React_Chat_Gap-winforms.7z
)

IF EXIST React_Chat_Gap-winforms.exe (
del React_Chat_Gap-winforms.exe
)

cd tools && 7za a ..\React_Chat_Gap-winforms.7z ..\staging-winforms\* && cd..
copy /b .\tools\7zsd_All.sfx + config-winforms.txt + React_Chat_Gap-winforms.7z React_Chat_Gap-winforms.exe