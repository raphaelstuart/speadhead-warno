@echo off
call .\.PATH.bat
..\Utils\Python\python.exe ..\Utils\Scripts\CreateModBackup.py %1
pause
