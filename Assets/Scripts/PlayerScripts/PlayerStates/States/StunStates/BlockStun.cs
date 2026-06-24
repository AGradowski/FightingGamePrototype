using UnityEngine;

public class BlockStun : Stun
{
    public BlockStun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("I got hit, but I block" + player.gameObject.name);

        //check for the attack that player was hit by, and do the onBlock recovery
        base.timeToRecover = player.playerHitManager.hitByCurrentAttack.blockStun;
        Debug.Log("Time to recover" + player.gameObject.name + base.timeToRecover);

        //TODO chip damage apply
        //TODO additional effects apply

        base.EnterState();
    }


}

