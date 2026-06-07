using UnityEngine;

public class AttackActive : PlayerState
{
    private float timeTillRecovery = 0;
    private float oneFrameTimer = 0;

    public AttackActive(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Activating attack");
        timeTillRecovery = player.currentAttack.activeFrames * (1.0f / 60);
        oneFrameTimer = 1.0f / 60;
        player.debugHitbox.GenerateVisualHitbox(player.currentAttack);
    }

    public override void ExitState()
    {
        player.debugHitbox.HideVisualHitbox();
    }

    public override void FrameUpdate()
    {

        timeTillRecovery -= Time.deltaTime;
        oneFrameTimer -= Time.deltaTime;
        //check the hitbox
        if (oneFrameTimer <= 0)
        {
            if (player.playerAttackController.ActivateHurtbox(player.currentAttack))
            {
                playerStateMachine.ChangeState(player.AttackRecovery);
                player.playerComboManager.addHit();
            }
            oneFrameTimer = 1.0f / 60;
        }

        base.FrameUpdate();
    }

    public override void PhysicsUpdate() { }

    public override void AnimationTriggerEvent() { }

    public override void TransitionChecks()
    {
        if (timeTillRecovery <= 0)
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
