using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoundStart : Cinematic
{
    //need to check, when the cinematic thing eneded, like cinematic Manager?
    //actually, always it will be both players
    public RoundStart(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }
    public override void EnterState()
    {
        Debug.Log("RoundStart " + player.gameObject.name);
        base.EnterState();
    }

    public override void TransitionChecks()
    {
        if (player.roundReady)
        {
            playerStateMachine.ChangeState(player.IdleState);
            return;
        }
        base.TransitionChecks();
    }


}
