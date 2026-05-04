using UnityEngine;

public class HitStun : Stun
{

    public HitStun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("I got hit" + player.gameObject.name);
        player.playerHealthManager.ApplyDamage(player.playerHitManager.currentAttack.damage);
        base.timeToRecover = player.playerHitManager.currentAttack.hitStun * (1.0f / 60);
        base.EnterState();
    }
}
