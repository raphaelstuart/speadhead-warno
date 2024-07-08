call .\.PATH.bat

%WNPATH:~0,2%
cd "%WNPATH%"
cd ".\SpearHead"

for %%* in (.) do set CurrDirName=%%~nx*
..\..\WARNO.exe -headless -datapackonly -uploadmod "%CurrDirName%" CommonData:Clusters/Bootstrap/ClusterBootstrapUploadMod.ndf
..\Utils\Python\python.exe ..\Utils\Scripts\CreateModBackup.py -autoname
