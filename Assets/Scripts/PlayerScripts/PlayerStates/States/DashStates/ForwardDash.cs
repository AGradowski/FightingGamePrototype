using UnityEngine;

public class ForwardDash : Dash
{
    public ForwardDash(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timeToExitDash = player.fwdDashLength;
    }

    public override void FrameUpdate()
    {
        player.playerMover.ForwardDashUpdate();
        base.FrameUpdate();
    }

}
