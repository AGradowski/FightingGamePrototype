using UnityEngine;

public class CrouchBlocking : Blocking
{
    public CrouchBlocking(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }
}
