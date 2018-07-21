How you can Contribute to Mod Maker (MM)
========================================

* 1) Promote MM in any place that Source modders visit or wherever you hear of anyone working on a task Mod Maker can do for them.
* 2) Report Issues at <https://github.com/ChromeAngel/ModMaker/issues> , in English, with the steps you took to produce them and (if possible) a copy of your system info ( Help->System Info )
* 3) Write documentation, in English, for MM in the wiki <https://github.com/ChromeAngel/ModMaker/wiki>
* 4) Record video tutorials for installing MM or using one of it's features, upload them to Youtube and link to them from the wiki.
* 5) Request new features by raising an Issue, In English, labelled as "enhancement", describing your feature and how you would like to access it from MM.
* 6) Make replacement Icons for the tools in MM.
* 7) Make a coding style document (I know such things exist and are supported by Visual Studio, i've just never had time to look into it).
* 8) Add features by branching the repo, making the changes and sending a pull request.
* 9) Fix bugs by branching the repo, making the changes and sending a pull request.

### 1. Features we would like to have:
* 1) Bug free (see Known Issues below).
* 2) Streamlined support for creating content-only mods.
* 3) Support for creating Alien Swarm mods.
* 4) Installers that can install Steam and the Source SDK if they are not found.
* 5) A "Modern" (Windows 8+) User Interface (and Windows Store presense)
* 6) Linux support, in both the Library and UI.
* 7) An installer for MM itself.
* 8) Generate mod installers that create shortcuts to allow SDK2013 mods to use the Steam Overlay.
* 9) A QC script editor and compiler front-end with syntax highlighting.
* 10) An asyncronous UI for the map compiler tools, so MM can tell Hammer to launch the UI, rather than get locked up waiting for the commandline compile tools to finish.

### 2. Known Issues:
* 1) MM doesn't run on all systems.  Steam and Source are pretty complicated systems and there are a wide variety of versions and configurations in use by modders in the wild.  MM *tries* to cope with every eventuality, but does not always succeed.  If MM does not work on your system please work with us (by raising an Issue), so that MM can work for you.
* 2) The Source file system compoment is quite new (at the time of writing) and may not 100% see the file system the way that HL2.exe does when the game runs.
* 3) Asynchronous progress bars for the download, zip and unzip processes rarely run smoothly, jumping from 0 to 100%.
* 4) Not all tools/features that could benefit from the Source file system make use of it (see 2) and have crappy mannual workarounds instead.  These should be modernized to use the Source file system component.
* 5) The weapon editor tool is fiddly, cranky and could use some finessing.

### 3.Rules of Conduct
Be curtious and polite in all communications, keeping in-mind that:
A) No one is getting paid for this.
B) English, while popular, is not universal.  The person you are communicating with may not be a native English speaker and is already struggling to understand English documentaion and tools, which can be frustraiting.
C) Avoid sarcasm and humor.  They do not translate well into writing.

Do not spam.  When promoting MM, avoid making more than 3 references to MM per person or site per day.  When raising Issues, please limit yourself to 5 Issues per day.  When raising an issue do a search to see if something like your issue has been raised before.  When making pull requests, please limit yourself to one feature per pull request and to 5 open pull requests at a time.

Give meaningful descriptions of the changes and additions you have made, in English, on your Git commits and pull requests, referencing related Issues where appropriate.  This will aid the project administrator and speed integration of your changes into the master branch.

Coders should use meaningful English names for classes, methods and variables in their code.  English comments in the standard format for each class and function about WHY they do what they do will be appreciated.  Coders should keep to the coding conventions (naming, tab, and bracket usage etc.) already used in the project.  This will aid and speed the project administrators review of your changes, prior to merging into the master branch.

Do not reference paid or commercial libraries in the code, we want to be able to keep MM free to distribute and use.