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


        if (player.inputInterpreter.GetNextCommand() is not null)
        {

            playerStateMachine.ChangeState(player.playerStatesManager.attackStartup);
            return;
        }
        if (moveInput == "5")
        {
            Debug.Log("Here");
            playerStateMachine.ChangeState(player.playerStatesManager.idleState);
            return;
        }
        if (moveInput == "6")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.movingState);
            return;
        }


        base.TransitionChecks();

    }
}
