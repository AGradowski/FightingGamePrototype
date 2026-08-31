using UnityEngine;

public class Dodge: PlayerState
{
    protected float timeToExitDodge;

    public Dodge(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    { 
    }



    public override void EnterState()
    {
        Debug.Log("Dodge " + player.gameObject.name);
        base.EnterState();
        timeToExitDodge = player.dodgeLength;


    }

    public override void FrameUpdate()
    {
        timeToExitDodge -= Time.deltaTime;
        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        if (timeToExitDodge <= 0)
        {
            Debug.Log("Dodge expired");
            playerStateMachine.ChangeState(player.IdleState);
        }
    }

}
