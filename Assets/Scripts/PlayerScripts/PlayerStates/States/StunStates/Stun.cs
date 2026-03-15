using UnityEngine;

public class Stun : PlayerState
{
    public Stun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    protected float timeToRecover = 0;

    public override void FrameUpdate()
    {
        Debug.Log("Waiting in stun" + player.gameObject.name + timeToRecover);
        timeToRecover -= Time.deltaTime;
        base.FrameUpdate();
    }

    public override void ExitState()
    {
        timeToRecover = 0;
        player.playerHitManager.ClearAttack();//just in case any attacks with multiple active frames, might need to handle it differently
                                              //but this migh also allow for things like chip damage, so might be good to keep?
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
