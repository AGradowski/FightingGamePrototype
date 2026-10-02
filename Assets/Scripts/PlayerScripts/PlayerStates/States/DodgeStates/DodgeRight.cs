using UnityEngine;

public class DodgeRight : Dodge
{
    private AttackDataObject attackInput;

    public DodgeRight(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Right");
        player.playerParticleManager.ActivateDodgeRight();
        //TODO Add particles

    }

    public override void ExitState()
    {
        player.playerParticleManager.StopDodgeRight();

        base.ExitState();
    }

    public override void FrameUpdate()
    {
        player.playerMover.DodgeUpdate("Right");
        attackInput = player.inputInterpreter.GetNextCommand();

        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        base.TransitionChecks();
        if (player.playerHitManager._IsHit && player.playerHitManager.hitByCurrentAttack.trackingType == AttackDataObject.AttackTracking.Right)
        {
            playerStateMachine.ChangeState(player.playerStatesManager.hitStun);
        }
        base.TransitionChecks();
    }

}