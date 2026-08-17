using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackDataObject", menuName = "Scriptable Objects/AttackDataObject", order = 1)]
public class AttackDataObject : ScriptableObject
{
    public int damage;
    public int startupFrames;//assuming 60 or 24 frames per second, this will be calculated later in the program frames/assuumedFramesOfAnimationPerSecond
    public int activeFrames;//assuming 60 or 24 frames per second, this will be calculated later in the program frames/assuumedFramesOfAnimationPerSecond
    public int recoveryFrames;//assuming 60 or 24 frames per second, this will be calculated later in the program frames/assuumedFramesOfAnimationPerSecond
    public int hitStun;
    public int blockStun;
    public string animationName;

    [Header("Combo data")]
    public float pushback;
    public bool isLauncher;
    public float launchHeight;
    public bool _IsCinematicHit;

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
    [Header("HitBoxData")]
    public HitBox[] hitBoxes;
}
