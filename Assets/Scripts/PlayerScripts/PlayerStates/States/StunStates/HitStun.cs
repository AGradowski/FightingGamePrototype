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
        if (player.playerHitManager._IsHit)
        {
            Debug.Log("COMBO");
            //Add combo counter
            if (player.playerHitManager.hitByCurrentAttack.isLauncher)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.launched);
                return;
            }
            if (player.playerHitManager.hitByCurrentAttack.knocksDown && player.player_body.isGrounded)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.knockDown);
                return;
            }
            playerStateMachine.ChangeState(player.playerStatesManager.hitStun);
        }
        base.TransitionChecks();   
    }
}
