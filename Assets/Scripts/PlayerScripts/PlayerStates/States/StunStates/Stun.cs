using UnityEngine;

public class Stun : PlayerState
{
    public Stun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    protected int timeToRecover = 0;

    public override void EnterState()
    {
        player.playerHitManager.ClearAttack();
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        timeToRecover -= 1;
        base.FrameUpdate();
    }

    public override void ExitState()
    {
        //just in case any attacks with multiple active frames, might need to handle it differently
        //but this migh also allow for things like chip damage, so might be good to keep?
        timeToRecover = 0;
        Debug.Log("Recovered " + player.gameObject.name);
    }

    public override void TransitionChecks()
    {
        if (timeToRecover <= 0)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }

}
