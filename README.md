# jms-weight-injector
A tool that enables new 3D character models to be created for the Halo game engine and imported into Halo Custom Edition.

Halo Custom Edition, a version of the game Halo for PC that enabled technically-minded players to create new levels, was released in 2004 by Gearbox Software. Players/modders were provided with the same programs and workflow that the designers and developers inside Bungie originally used to create the game Halo for Xbox, but with some features removed.

One feature that was not released to the community was the ability to add new characters to the game. A new 3D model could not be imported to give "Master Chief" a fundamentally different appearance. To add a new character to a game, it is important that characters are [rigged](https://en.wikipedia.org/wiki/Skeletal_animation) so they look correct when they are animated and move.

The missing link for adding a character to Halo Custom Edition was the exporting of this rigging information from 3ds Max (a 3D modelling package) into the game's editing tools. The exporter provided by Gearbox Software, called Blitzkrieg, could export a 3D mesh but did not export this vital rigging information with it.

The tool I wrote back in July 2006 allows someone to combine a mesh they have exported from 3ds Max (into a JMS file) with a separate file that describes the rigging of the mesh. It opens and interprets the JMS file, matches the vertices of the 3D mesh with those in the supplied rigging file, and injects this rigging information into the JMS file for each vertex it matches. This JMS file can then be processed by the rest of the Halo Custom Edition tool chain, and allows the importing of fully functioning new character models into the game.