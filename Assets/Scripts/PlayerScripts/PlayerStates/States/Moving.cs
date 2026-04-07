using UnityEngine;

public class Moving : PlayerState
{
    private string moveInput = "";
    private AttackDataObject attackInput = null;

    public Moving(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }
    public override void EnterState()
    {
        Debug.Log("Entering Moving");
        base.EnterState();

    }

    public override void ExitState()
    {
        player.playerMover.StopPlayer();
    }

    public override void FrameUpdate()
    {

        moveInput = player.inputInterpreter.GetMovementInput();
        attackInput = player.inputInterpreter.GetNextCommand();
        //  Debug.Log("Moving");
        player.playerMover.MovePlayer();

        base.FrameUpdate();


        //check the input buffer
        //action based on it
        //Debug.Log(player.inputBuffer.ConsumeInput());
        // playerStateMachine.ChangeState(player.MovingState);

    }

    public override void TransitionChecks()
    {

        if (player.playerHitManager._IsHit)
        {
            playerStateMachine.ChangeState(player.HitStun);
        }
        if (player.inputInterpreter.GetNextCommand() is not null)
        {

            playerStateMachine.ChangeState(player.AttackStartup);
            return;
        }
        if (moveInput == "")
        {
            playerStateMachine.ChangeState(player.IdleState);
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
