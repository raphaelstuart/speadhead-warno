call .\.PATH.bat

%SDPATH:~0,2%
cd "%SDPATH%"
cd ".\SpearHead Assets"
call .\GenerateMod.bat

set sd_mod_gen_path=%HOMEDRIVE%%HOMEPATH%\Saved Games\EugenSystems\SteelDivision2\mod\SpearHead Assets
set warno_mod_gen_path=%HOMEDRIVE%%HOMEPATH%\Saved Games\EugenSystems\WARNO\mod\SpearHead

echo d|xcopy /s /y "%sd_mod_gen_path%\Localisation" "%warno_mod_gen_path%\Localisation"
echo d|xcopy /s /y "%sd_mod_gen_path%\PC" "%warno_mod_gen_path%\PC"