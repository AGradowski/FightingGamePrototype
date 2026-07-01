using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cinematic : PlayerState
{
    //need to check, when the cinematic thing eneded, like cinematic Manager?
    //actually, always it will be both players
    public Cinematic(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }



    public override void EnterState()
    {
        Debug.Log("Cinematic " + player.gameObject.name);
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void TransitionChecks()
    {

        base.TransitionChecks();
    }


}
