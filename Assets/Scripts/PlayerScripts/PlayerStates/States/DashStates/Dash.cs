using UnityEngine;

public class Dash : PlayerState
{
    public Dash(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }

    protected float timeToExitDash = 0;

    public override void EnterState()
    {
        base.EnterState();
        //timeToExitDash = player.backDashLength;
    }

    public override void FrameUpdate()
    {
        timeToExitDash -= Time.deltaTime;
        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {
        if (player.playerHitManager._IsHit)
        {
            timeToExitDash = 0;
            Debug.Log("HIT SEEN");
            if (player.playerHitManager._IsCinematicHit)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.hitStun);
                return;

            }
            if (player.playerHitManager.hitByCurrentAttack.knocksDown)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.knockDown);
                return;
            }
            if (player.playerHitManager.hitByCurrentAttack.isLauncher)
            {
                playerStateMachine.ChangeState(player.playerStatesManager.launched);
                return;
            }
            playerStateMachine.ChangeState(player.playerStatesManager.hitStun);
            return;

        }
        if (timeToExitDash <= 0)
        {
            Debug.Log("Dash finished");
            playerStateMachine.ChangeState(player.playerStatesManager.idleState);
        }
        base.TransitionChecks();
    }
}
