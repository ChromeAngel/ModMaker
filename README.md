Mod Maker
=========

Mod Maker (MM) is primarily a Source mod and tool launcher with productivity features to make it easier to mod for Source including: 2013 Mod Creation, Mod Shortcuts, Automatic Source SDK configuration, FGD editor, RES editor, Compiler, Mod Localization, RAD file editor, Steampipe packing, Installer and Patch file creation.

Features include (but are not limited to) :

* 2013 Mod Creation
* Shortcuts for all your mod's important files and folders
* Automatic Source SDK configuration
* FGD editor / entity creator
* Drag and drop model compiling
* Mod Localization
* RAD file editor
* VGUI RES editor
* Weapon Editor
* Chapter Maker
* Key Menu Editor
* Sound Scripter
* Steampipe packing
* Installer and Patch file creation

MM was something I (ChromeAngel) built over the years of Source mod development to help me with repetative or obscure tasks.  As such it has just enough polish to be useable to me, but I could always just fire up visual studio and debug it when it broke... which meant the build quality was not as solid as it could have been.  By opening the mod maker source I hope more developers will be able to benefit from the time savings that Mod Maker can bring.

### Downloads
If you just want to download a pre-compiled version, the latest stable build is at: <https://www.moddb.com/members/chromeangel/downloads/modmaker-v2>
### Structure
MM is developed in C# using Visual Studio 2015.  The soloution (ModMaker.sln) contains 2 main projects and some offshoots:

* LibModMaker - Contains abstract classes that encode the behaviour and structures of Steam, Source Games, Source Mods, Source File Systems and KeyValue files.
* ModMaker - The winforms user interface, thank makes use of LibModMaker and is rooted in its main form and the ModView control.  This project contains many Tool classess, that impliment the iTool interface and provide stand -alone features, like setting up the SDK, launching hammer or scripting chapters.
* WarHammmer - A standalone app that uses LibModMaker to configure and launch the SDK and Hammer to enable an easier start to mapping for a specific mod.
* ModMakerTests - Some basic experimentation with automated testing and samples of various file formats.

### Help the Project
Even if you are not a programmer or an artist you *can* help this project, read CONTRIBUTION.md to find out how.
