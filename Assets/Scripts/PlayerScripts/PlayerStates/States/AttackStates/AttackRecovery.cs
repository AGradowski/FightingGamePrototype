using UnityEngine;

public class AttackRecovery : PlayerState
{
    public AttackRecovery(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }


    public override void EnterState()
    {
        //currentAttack = player.inputInterpreter.GetNextCommand();
        // player.playerAnimatorScript.PlayAnimation(currentAttack.animationName);
        // Debug.Log("Attacking " + currentAttack);
        // Debug.Log(currentAttack);
        Debug.Log("Recovering attack");

    }

    public override void ExitState()
    {

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate() { }

    public override void AnimationTriggerEvent() { }

    public override void TransitionChecks()
    {
        //base.TransitionChecks();
        // Debug.Log(currentAttack);

        if (!player.animator.GetCurrentAnimatorStateInfo(0).IsName(player.currentAttack.animationName))
        {
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");//IT gets here once, then does it again?
            player.currentAttack = null;
            playerStateMachine.ChangeState(player.IdleState);
            return;
        }
        if (player.playerHitManager._IsHit)
        {
            playerStateMachine.ChangeState(player.HitStun);
        }

        //if (timeTillActive <= 0)
        //  {
        //GOTO attack active
        //TODO change this to attack startup
        //TODO remove the above
        //TODO add counterhit state and check
        //      player.playerAttackController.ActivateHurtbox(currentAttack);
        //  }
        //TODO add check for the if was counterhit, or better to make the state machine check it? When entering counterhit/hit states?
        //TODO add checking, when one part of animation is finished, so that the hurtbox can be deployed
    }
}
