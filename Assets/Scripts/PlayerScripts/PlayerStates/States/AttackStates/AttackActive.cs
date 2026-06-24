using UnityEngine;

public class AttackActive : PlayerState
{
    private int frameTillRecovery = 0;//number of frames the attack should be active

    public AttackActive(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Activating attack");
        frameTillRecovery = player.currentAttack.activeFrames;
        player.debugHitbox.GenerateVisualHitbox(player.currentAttack);
    }

    public override void ExitState()
    {
        player.debugHitbox.HideVisualHitbox();
    }

    public override void FrameUpdate()
    {

        frameTillRecovery -= 1;
        //check the hitbox, each frame it is active
        if (player.playerAttackController.ActivateHurtbox(player.currentAttack))
        {
            playerStateMachine.ChangeState(player.AttackRecovery);
            player.playerComboManager.addHit();
        }

        base.FrameUpdate();
    }

    public override void PhysicsUpdate() { }

    public override void AnimationTriggerEvent() { }

    public override void TransitionChecks()
    {
        if (frameTillRecovery <= 0)
        {
            //GOTO attack active
            //TODO change this to attack startup
            //TODO remove the above
            //TODO add counterhit state and check
            playerStateMachine.ChangeState(player.AttackRecovery);
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
