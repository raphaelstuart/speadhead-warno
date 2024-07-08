# speadhead-warno
SpearHead mod for warno

THE MOD IS NOT CAPABLE WITH LATEST VERSION OF WARNO PLEASE UPDATE IT FIRST.

## Startup
1. Copy and paste `.PATH.bat.template` and rename the new file to `.PATH.bat` 
2. Edit `.PATH.bat` and modify `WNPATH` and `SDPATH` variable. Set them to your WARNO and SD2 mods folder path.
3. Use Terminal(Administrator) to run `LinkProject.bat` to create symbol link of mod folders under your game installation location. 

## Build Mod
1. Build mod using `GenerateMod.bat`
2. If you get an error on build and tell you some definitions not found. Please run `rmgen.bat` and try to rebuild it.
3. This is an Eugen bug so try 2 to 3 times if error still there you should check your code. 

## Upload Mod
1. Build mod using `GenerateMod.bat`
2. Open `C:\Users\{USERNAME}\Saved Games\EugenSystems\WARNO\mod\SpearHead\Config.ini` set MODID to 3174643645(Official release id and i will add you as an author)
3. If you wanna release a copy of this mod, you do not need to modify the MODID.
4. Edit the title and description in `Config.ini` or on steam workshop page.
5. Upload mod using `UploadMod.bat`.

## Reminder Of File Usages
> Inf model and weapon  
GameData/Generated/Gameplay/Gfx/Infanterie/GeneratedDepictionInfantry.ndf  
GameData/Generated/Gameplay/Gfx/Infanterie/GeneratedInfanterieWeaponsUnites.ndf  

> Trajectory and sound   
GameData/Generated/Gameplay/Gfx/GeneratedDepictionWeaponBlock.ndf  

> Vehicles   
GameData/Generated/Gameplay/Gfx/Depictions/GeneratedDepictionVehicles.ndf  

> Constants(Supply range, Startup res...)  
GameData/Gameplay/Constantes/GDConstantes.ndf  
GameData/Gameplay/Constantes/Ravitaillement.ndf   

> Aircrafts panel  
GameData/UserInterface/Use/InGame/UISpecificOffMapView.ndf   
GameData/UserInterface/Use/InGame/UISpecificOffMapAirplaneView.ndf   

> Terrain data  
GameData/Gameplay/Terrains/Terrains.ndf  

> Units data  
GameData/Generated/Gameplay/Gfx/Ammunition.ndf  
GameData/Generated/Gameplay/Gfx/AmmunitionMissiles.ndf  
GameData/Generated/Gameplay/Gfx/BuildingDescriptors.ndf  
GameData/Generated/Gameplay/Gfx/DistrictsDescriptor.ndf  
GameData/Generated/Gameplay/Gfx/ShowRoomEquivalence.ndf  
GameData/Generated/Gameplay/Gfx/ShowRoomUnits.ndf   
GameData/Generated/Gameplay/Gfx/UniteCadavreDescriptor.ndf  //add dead damage u can make it as an IED  
GameData/Generated/Gameplay/Gfx/UniteDescriptor.ndf  
GameData/Generated/Gameplay/Gfx/WeaponDescriptor.ndf  
GameData/Generated/Gameplay/Gfx/MissileDescriptors.ndf  

> Units orders(If you add supply or load/unload to a unit you should add orders to it)   
GameData/Generated/Gameplay/Gfx/OrderAvailability_Tactic.ndf  

> Division data  
GameData/Generated/Gameplay/Decks/Decks.ndf  
GameData/Generated/Gameplay/Decks/DeckSerializer.ndf   
GameData/Generated/Gameplay/Decks/DivisionCostMatrix.ndf  
GameData/Generated/Gameplay/Decks/DivisionList.ndf  
GameData/Generated/Gameplay/Decks/DivisionRules.ndf  
GameData/Generated/Gameplay/Decks/Divisions.ndf  
GameData/Generated/Gameplay/Decks/Packs.ndf   

> Icons  
GameData/Generated/UserInterface/Textures/DivisionTextures.ndf    
GameData/Generated/UserInterface/Textures/ButtonTexturesUnites.ndf  
GameData/Generated/UserInterface/Textures/WeaponTextures.ndf  

> Terrain effect popup ui   
GameData/UserInterface/Use/InGame/UIMousePolicyResources.ndf  

> Add new nation  
GameData/UserInterface/Use/Common/UISpecificCountriesInfos.ndf  
GameData/UserInterface/Use/ShowRoom/UIShowRoomResources.ndf    
  
> Four columns of weapon  
GameData/UserInterface/Use/InGame/UISpecificUnitInfoPanelView.ndf  

> Vehicle crew models  
GameData/Generated/Gameplay/Gfx/Depictions/GeneratedDepictionHumans.ndf  
GameData/Generated/Gameplay/Gfx/Depictions/GeneratedDepictionVehiclesShowroom.ndf  
 
> Missile loads  
GameData/Generated/Gameplay/Gfx/MissileCarriageDepiction.ndf  
GameData/Generated/Gameplay/Gfx/Depictions/GeneratedDepictionAerialUnits.ndf  
GameData/Generated/Gameplay/Gfx/Depictions/GeneratedDepictionAerialUnitsShowroom.ndf  