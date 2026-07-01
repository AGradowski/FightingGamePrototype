using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launched : PlayerState
{
    //needs to check, when on the ground, then leave
    public Launched(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }


}
