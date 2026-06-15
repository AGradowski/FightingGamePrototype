# Attack Scripts

The folder for containg the documentation for anything relaed to the Attack as an object.

## Attack Data Object

The Attack object - attack, or move in the FGC nomenclature. All the move data, required to make the character attack will be here. Also grabs, stances, counters etc.

Made using the scriptable object Unity [Concept](https://docs.unity3d.com/6000.3/Documentation/Manual/class-ScriptableObject.html)

* damage (int)  
* startup

## Directional Attack

A seperate data structure, for containing the information about the direction from which the attack came - TODO - change this to a child of the Attack Data Object
