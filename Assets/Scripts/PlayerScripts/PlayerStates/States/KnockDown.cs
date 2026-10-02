using System.Collections;
using UnityEngine;


public class KnockDown : PlayerState
{
    private float knockDownTimer = 0;
    public KnockDown(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {

    }
    public override void EnterState()
    {
        Debug.Log("Knockdown " + player.gameObject.name);
        player.playerHitBoxManager.SetStateHurtboxes(this);
        player.playerHitManager.ClearAttack();
        knockDownTimer = 3;
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        knockDownTimer -= Time.deltaTime;
        base.FrameUpdate();
    }
    public override void TransitionChecks()
    {
        if (knockDownTimer <= 0)
        {
            playerStateMachine.ChangeState(player.playerStatesManager.wakeUp);
        }
        if(player.playerHitManager._IsHit)
        {
            player.playerHitManager.ClearAttack();//For now just ignore damage
        }
        base.TransitionChecks();
    }
}
