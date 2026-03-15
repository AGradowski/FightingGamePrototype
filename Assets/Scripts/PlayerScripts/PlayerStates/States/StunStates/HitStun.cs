using UnityEngine;

public class HitStun : Stun
{
    // private float timeInStun = 0f;

    public HitStun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("I got hit" + player.gameObject.name);
        player.playerHealthManager.ApplyDamage(player.playerHitManager.currentAttack.damage);
        base.timeToRecover = player.playerHitManager.currentAttack.hitStun;
        //  player.playerHitManager.ClearAttack();
        //animationController.SetTrigger(animationName);
    }
}
