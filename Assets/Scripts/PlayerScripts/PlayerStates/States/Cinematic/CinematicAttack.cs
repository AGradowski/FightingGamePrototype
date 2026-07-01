using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinematicAttack : Cinematic
{
    public CinematicAttack(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        isAnimationFinished = false;
        isExitingState = false;
        startTime = Time.time;
        player.animator.Play(player.currentAttack.animationName);//this is for the attacking player
        //for the player hit, need another state
    }

    public override void TransitionChecks()
    {

        if (!player.animator.GetCurrentAnimatorStateInfo(0).IsName(player.currentAttack.animationName))
        {
            player.currentAttack = null;
            playerStateMachine.ChangeState(player.IdleState);
            return;
        }
        base.TransitionChecks();
    }
}
