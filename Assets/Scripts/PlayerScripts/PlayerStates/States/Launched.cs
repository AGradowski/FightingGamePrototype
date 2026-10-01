using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launched : PlayerState
{
    //needs to check, when on the ground, then leave
    public Launched(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        //big force up
        player.playerHealthManager.ApplyDamage(player.playerHitManager.hitByCurrentAttack.damage);
        player.playerMover.Launch(10);

        base.EnterState();
    }

    public override void FrameUpdate()
    {
        //if hit, bump up, by smaller and smaller amounts - based on the combo meter
        if(player.playerHitManager._IsHit)
        {
            int combo = player.other_Player.GetComponent<Player>().playerComboManager.getComboMeter();
            if (combo != 0)
            {
                Vector3 launchVector = 10 / combo * Vector3.up;
                player.playerMover.Launch(1 / combo);
                player.playerHealthManager.ApplyDamage(player.playerHitManager.hitByCurrentAttack.damage);
                player.playerHitManager.ClearAttack();
            }
        }
        player.playerMover.ApplyGravity();
        //if not, fall down
        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        if(player.player_body.isGrounded)
        {
            playerStateMachine.ChangeState(player.KnockDown);
            return;
        }
        if (player.playerHitManager._IsHit)
        {
            Debug.Log("COMBO");
            //Add combo counter
            if (player.playerHitManager.hitByCurrentAttack.isLauncher)
            {
                playerStateMachine.ChangeState(player.Launched);
                return;
            }
            if (player.playerHitManager.hitByCurrentAttack.knocksDown && player.player_body.isGrounded)
            {
                playerStateMachine.ChangeState(player.KnockDown);
                return;
            }
            playerStateMachine.ChangeState(player.HitStun);
        }
        base.TransitionChecks();
    }
}
