using UnityEngine;

public class CrouchBlockStun : Stun
{
    public CrouchBlockStun(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("I got hit, but I block crouching" + player.gameObject.name);


        //ooooo, noo, not the correct attack
        base.timeToRecover = player.playerHitManager.currentAttack.blockStun * (1.0f / 60);
        Debug.Log("Time to recover" + player.gameObject.name + base.timeToRecover);
        //player.playerHitManager.ClearAttack();
        //animationController.SetTrigger(animationName);
        //chip damage apply
        //additional effects apply
        base.EnterState();
    }
}
