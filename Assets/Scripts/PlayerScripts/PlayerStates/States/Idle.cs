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

        //check the input buffer
        //action based on it
        //Debug.Log(player.inputBuffer.ConsumeInput());
        // playerStateMachine.ChangeState(player.MovingState);

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
        base.TransitionChecks();
    }
}
