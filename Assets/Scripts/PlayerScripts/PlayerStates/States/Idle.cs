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
        player.playerHitBoxManager.SetStateHurtboxes(this);
        player.playerHitManager.ClearAttack();
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
                playerStateMachine.ChangeState(player.playerStatesManager.hitStun);
                return;

            }
            if (player.playerHitManager.hitByCurrentAttack.knocksDown)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.knockDown);
                return;
            }
            if (player.playerHitManager.hitByCurrentAttack.isLauncher)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.launched);
                return;
            }
            playerStateMachine.ChangeState(player.playerStatesManager.hitStun);

        }
        if (player.inputInterpreter.GetNextCommand() is not null)
        {
            playerStateMachine.ChangeState(player.playerStatesManager.attackStartup);
            return;
        }
        if (moveInput == "6")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.movingState);
            return;
        }
        if (moveInput == "4")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.standBlockingState);
            return;
        }
        if (moveInput == "1")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.crouchBlockingState);
            return;
        }
        if (moveInput == "8")//up, towards the screen
        {
            if(player.CheckSide() == "Left")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeLeft);
            }
            else if (player.CheckSide() == "Right")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeRight);
            }
            return;
        }
        if (moveInput == "2")//down, out of the screen
        {
            if (player.CheckSide() == "Right")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeLeft);
            }
            else if (player.CheckSide() == "Left")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeRight);
            }
            return;
        }
        base.TransitionChecks();
    }
}
