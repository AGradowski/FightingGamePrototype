using UnityEngine;

public class StandBlocking : Blocking
{
    public StandBlocking(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Stand Blocking");
        base.EnterState();
    }


    public override void FrameUpdate()
    {
        base.moveInput = player.inputInterpreter.GetMovementInput();
        base.attackInput = player.inputInterpreter.GetNextCommand();
        player.playerMover.MovePlayer();
        base.FrameUpdate();
    }
}
