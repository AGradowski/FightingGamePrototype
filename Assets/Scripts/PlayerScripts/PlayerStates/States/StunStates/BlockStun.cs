using UnityEngine;

public class BlockStun : Stun
{
    public BlockStun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("I got hit, but I block" + player.gameObject.name);


        //ooooo, noo, not the correct attack
        base.timeToRecover = player.playerHitManager.currentAttack.blockStun;
        //player.playerHitManager.ClearAttack();
        //animationController.SetTrigger(animationName);
        //chip damage apply
        //additional effects apply
    }


}

