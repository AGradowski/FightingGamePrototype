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
        //Debug.Log("Idle" + player.gameObject.name);

    }

    public override void ExitState()
    {
        attackInput = null;
    }

    public override void FrameUpdate()
    {

        moveInput = player.inputInterpreter.GetMovementInput();

        //        Debug.Log(moveInput + player.gameObject.name);
        attackInput = player.inputInterpreter.GetNextCommand();
        player.animator.Play("Idle");
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
            playerStateMachine.ChangeState(player.HitStun);
        }
        // base.TransitionChecks();
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
        base.TransitionChecks();
    }
}
