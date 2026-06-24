using UnityEngine;

public class AttackStartup : PlayerState
{
    public AttackStartup(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    //private AttackDataObject currentAttack = null;
    private int timeTillActive = 0;


    public override void EnterState()
    {
        //TODO possible issue with data locality, and using player for storing attack
        // on the other hand, queueing attack in a string will probably be 100% handled eitehr by player, or some of its components
        //besides, first make it work, then optimize
        player.currentAttack = player.inputInterpreter.GetNextCommand();
        player.playerAnimatorScript.PlayAnimation(player.currentAttack.animationName);
        Debug.Log("Attacking " + player.currentAttack.animationName);
        Debug.Log(player.currentAttack);
        timeTillActive = player.currentAttack.startupFrames;

    }

    public override void ExitState()
    {

    }

    public override void FrameUpdate()
    {
        timeTillActive -= 1;
        //check the hitbox

        base.FrameUpdate();
    }

    public override void PhysicsUpdate() { }

    public override void AnimationTriggerEvent() { }

    public override void TransitionChecks()
    {
        //base.TransitionChecks();
        // Debug.Log(currentAttack);

        // if (!player.animator.GetCurrentAnimatorStateInfo(0).IsName(player.currentAttack.animationName))
        //{
        //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");//IT gets here once, then does it again?
        //  player.currentAttack = null;
        // playerStateMachine.ChangeState(player.IdleState);
        // return;
        // }
        if (timeTillActive <= 0)
        {
            //GOTO attack active
            //TODO change this to attack startup
            //TODO remove the above
            //TODO add counterhit state and check
            playerStateMachine.ChangeState(player.AttackActive);
        }
        //TODO add check for the if was counterhit, or better to make the state machine check it? When entering counterhit/hit states?
        //TODO add checking, when one part of animation is finished, so that the hurtbox can be deployed
    }
}