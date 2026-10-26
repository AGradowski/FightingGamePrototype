using UnityEngine;

public class BackDash : Dash
{
    public BackDash(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timeToExitDash = player.backDashLength;
    }

    public override void FrameUpdate()
    {
        player.playerMover.BackDashUpdate();
        base.FrameUpdate();
    }
}
