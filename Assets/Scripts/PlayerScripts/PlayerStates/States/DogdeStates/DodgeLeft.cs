using UnityEngine;

public class DodgeLeft:Dodge
{
    private AttackDataObject attackInput;

    public DodgeLeft(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {

    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Left");
       
        //player.transform.RotateAround()
        //TODO Adsd particles
    }

    public override void FrameUpdate()
    {
        player.playerMover.Dodge("Left");
        attackInput = player.inputInterpreter.GetNextCommand();
        //player.playerMover.MovePlayer();
        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        
        if(player.playerHitManager._IsHit && player.playerHitManager.hitByCurrentAttack.trackingType == AttackDataObject.AttackTracking.Left)
        {
            playerStateMachine.ChangeState(player.HitStun);
        }
        base.TransitionChecks();
    }
}
