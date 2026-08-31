using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Idle : PlayerState
{
    private string moveInput = "";
    private AttackDataObject attackInput = null;
    public Idle(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {

        Debug.Log("Idle " + player.gameObject.name);
        Actions.PlayerRecoveredAfterHits(player);
        base.EnterState();
    }


    public override void ExitState()
    {
        attackInput = null;
    }

    public override void FrameUpdate()
    {

        moveInput = player.inputInterpreter.GetMovementInput();

        attackInput = player.inputInterpreter.GetNextCommand();
        base.FrameUpdate();
    }
    public override void PhysicsUpdate() { }

    public override void AnimationTriggerEvent() { }

    public override void TransitionChecks()
    {
        if (player.playerHitManager._IsHit)
        {
            Debug.Log("HIT SEEN");
            if (player.playerHitManager._IsCinematicHit)
            {
                playerStateMachine.ChangeState(player.HitStun);

            }
            else
            {
                playerStateMachine.ChangeState(player.HitStun);
            }

        }
        if (player.inputInterpreter.GetNextCommand() is not null)
        {
            playerStateMachine.ChangeState(player.AttackStartup);
            return;
        }
        if (moveInput == "6")
        {
            playerStateMachine.ChangeState(player.MovingState);
            return;
        }
        if (moveInput == "4")
        {
            playerStateMachine.ChangeState(player.StandBlockingState);
            return;
        }
        if (moveInput == "1")
        {
            playerStateMachine.ChangeState(player.CrouchBlockingState);
            return;
        }
        if (moveInput == "8")//so up, towards the sceen
        {
            if(player.CheckSide() == "Left")
            {
                playerStateMachine.ChangeState(player.DodgeLeft);
            }else if(player.CheckSide() == "Right")
            {
                playerStateMachine.ChangeState(player.DodgeRight);

            }

            return;
        }
        if (moveInput == "2")
        {
            if (player.CheckSide() == "Right")
            {
                playerStateMachine.ChangeState(player.DodgeLeft);
            }
            else if (player.CheckSide() == "Left")
            {
                playerStateMachine.ChangeState(player.DodgeRight);

            }
            return;
        }
        base.TransitionChecks();
    }
}
