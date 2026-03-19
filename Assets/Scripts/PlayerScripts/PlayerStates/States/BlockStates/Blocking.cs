using UnityEngine;

public class Blocking : PlayerState
{

    public Blocking(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    protected string moveInput = "";
    protected AttackDataObject attackInput = null;
    public override void EnterState()
    {
        Debug.Log("Blocking");
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
        //
        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        if (player.playerHitManager._IsHit)
        {
            Debug.Log("Attempting to Change state" + player.gameObject.name);
            playerStateMachine.ChangeState(player.BlockStun);//add celaring of the state, as it is being confirmed
            return;
        }

        if (player.inputInterpreter.GetNextCommand() is not null)
        {

            playerStateMachine.ChangeState(player.AttackStartup);
            return;
        }
        if (moveInput == "")
        {
            Debug.Log("HERE");
            playerStateMachine.ChangeState(player.IdleState);
            return;
        }
        if (moveInput == "6")
        {
            playerStateMachine.ChangeState(player.MovingState);
            return;
        }
        base.TransitionChecks();

    }
}
