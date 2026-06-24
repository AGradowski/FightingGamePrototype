using UnityEngine;

public class HitStun : Stun
{

    public HitStun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("I got hit" + player.gameObject.name);
        player.playerHealthManager.ApplyDamage(player.playerHitManager.hitByCurrentAttack.damage);
        player.playerMover.PushPlayer(player.playerHitManager.hitByCurrentAttack.pushback, player.playerHitManager.currentEnemyForwardVector);
        base.timeToRecover = player.playerHitManager.hitByCurrentAttack.hitStun;
        base.EnterState();
    }

    public override void TransitionChecks()
    {
        base.TransitionChecks();
        if (player.playerHitManager._IsHit)
        {
            Debug.Log("COMBO");
            playerStateMachine.ChangeState(player.HitStun);
        }
    }


}
