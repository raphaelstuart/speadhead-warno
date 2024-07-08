call .\.PATH.bat

%WNPATH:~0,2%
cd "%WNPATH%"
cd ".\SpearHead"

for %%* in (.) do set CurrDirName=%%~nx*
..\..\WARNO.exe -headless -datapackonly -generatemod "Mods/%CurrDirName%/" CommonData:Clusters/Bootstrap/ClusterBootstrapGeneration.ndf
