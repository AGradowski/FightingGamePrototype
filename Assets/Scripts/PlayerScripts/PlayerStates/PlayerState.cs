using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected Animator animationController; //TO BE ADDED IN CONSTRUCTOR
    public string animationName; //TO BE ADDED IN CONSTRUCTOR

    protected bool isExitingState;
    protected bool isAnimationFinished;
    protected float startTime;
    //Other?

    //animation boolean ??? what is it? https://medium.com/@jojackblack/building-a-state-machine-in-unity-with-c-b1c7c9c80a04
    public PlayerState(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName)
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
        this.animationController = animationController;
        this.animationName = animationName;
    }

    public virtual void EnterState()
    {
        isAnimationFinished = false;
        isExitingState = false;
        startTime = Time.time;
        player.animator.Play(animationName);//HERE FOR ANIMATION PLAYING
        // animationController.SetBool(animationName, true);
    }

    public virtual void ExitState()
    {
        isExitingState = true;
        if (!isAnimationFinished) isAnimationFinished = true;
        //animationController.SetBool(animationName, false);
    }

    public virtual void FrameUpdate()
    {
        TransitionChecks();
    }

    public virtual void TransitionChecks()
    {

    }

    public virtual void PhysicsUpdate() { }

    public virtual void AnimationTriggerEvent()
    {
        isAnimationFinished = true;
    }
}
