using UnityEngine;

public class DodgeRight:Dodge
{
    private AttackDataObject attackInput;
    public DodgeRight(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Right");
        
    }

    public override void FrameUpdate()
    {
        player.playerMover.Dodge("Right");
       // moveInput = player.inputInterpreter.GetMovementInput();
        attackInput = player.inputInterpreter.GetNextCommand();
       // player.playerMover.MovePlayer();

        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        base.TransitionChecks();
        if (player.playerHitManager._IsHit && player.playerHitManager.hitByCurrentAttack.trackingType == AttackDataObject.AttackTracking.Right)
        {
            playerStateMachine.ChangeState(player.HitStun);
        }
        base.TransitionChecks();
    }

}
