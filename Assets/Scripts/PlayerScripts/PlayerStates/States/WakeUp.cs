using UnityEngine;

public class WakeUp : PlayerState
{
    private float wakeUpTimer;
    public WakeUp(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        wakeUpTimer = 3;
        base.EnterState();
    }
    public override void FrameUpdate()
    {
        wakeUpTimer -= Time.deltaTime; 
        base.FrameUpdate();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void TransitionChecks()
    {
        if (wakeUpTimer < 0)
        {
            playerStateMachine.ChangeState(player.playerStatesManager.idleState);
        }
        base.TransitionChecks();
    }
}
