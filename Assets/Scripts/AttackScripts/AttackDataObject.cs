using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackDataObject", menuName = "Scriptable Objects/AttackDataObject", order = 1)]
public class AttackDataObject : ScriptableObject
{
    public int damage;
    public int startupFrames;//assuming 60 or 24 frames per second, this will be calculated later in the program frames/assuumedFramesOfAnimationPerSecond

    public int activeFrames;//assuming 60 or 24 frames per second, this will be calculated later in the program frames/assuumedFramesOfAnimationPerSecond

    public float recoveryFrames;//assuming 60 or 24 frames per second, this will be calculated later in the program frames/assuumedFramesOfAnimationPerSecond

    public float hitStun;
    public float blockStun;
    public string animationName;

    [Header("Combo data")]
    public float pushback;
    public bool isLauncher;
    public float launchHeight;

    public enum AttackType
    {
        High,
        Medium,
        Low
    }
    [Header("Other")]
    public AttackType attackType;

    [Header("Input")]
    public string input; //ENUM

    //Attack strings? to which attack it goes? - possibly array of attacks?

    //TODO - so much more, now just a simple punch will suffice
    [Header("HurtBoxData")]
    public Vector3 origin; //possibly add more hurtboxes, for better customization
    public Vector3 size;
    public float radius;



}
