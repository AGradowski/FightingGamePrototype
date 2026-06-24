using UnityEngine;

public class CrouchBlocking : Blocking
{
    public CrouchBlocking(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Crouch Blocking");
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        base.moveInput = player.inputInterpreter.GetMovementInput();
        base.attackInput = player.inputInterpreter.GetNextCommand();
        player.playerMover.MovePlayer();
        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        if (player.playerHitManager._IsHit && player.playerHitManager.hitByCurrentAttack.attackType == AttackDataObject.AttackType.Low)
        {
            Debug.Log("Attempting to Change state" + player.gameObject.name);
            playerStateMachine.ChangeState(player.CrouchBlockStun);//add celaring of the state, as it is being confirmed
            return;
        }
        if (player.playerHitManager._IsHit && player.playerHitManager.hitByCurrentAttack.attackType == AttackDataObject.AttackType.Medium)
        {
            Debug.Log("Attempting to Change state" + player.gameObject.name);
            playerStateMachine.ChangeState(player.HitStun);//add celaring of the state, as it is being confirmed
            return;
        }
        if (moveInput == "4")
        {
            playerStateMachine.ChangeState(player.StandBlockingState);
            return;
        }

        base.TransitionChecks();
    }
}
