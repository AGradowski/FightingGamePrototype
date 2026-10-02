using UnityEngine;

public class Moving : PlayerState
{
    private string moveInput = "";
    private AttackDataObject attackInput = null;

    public Moving(Player player, PlayerStateMachine playerStateMachine, Animator animationController, string animationName) : base(player, playerStateMachine, animationController, animationName)
    {
    }
    public override void EnterState()
    {
        Debug.Log("Entering Moving");
        base.EnterState();

    }

    public override void ExitState()
    {
        player.playerMover.StopPlayer();
    }

    public override void FrameUpdate()
    {

        moveInput = player.inputInterpreter.GetMovementInput();
        attackInput = player.inputInterpreter.GetNextCommand();
        player.playerMover.MovePlayer();

        base.FrameUpdate();
    }

    public override void TransitionChecks()
    {

        if (player.playerHitManager._IsHit)
        {
            playerStateMachine.ChangeState(player.playerStatesManager.hitStun);
        }
        if (player.inputInterpreter.GetNextCommand() is not null)
        {

            playerStateMachine.ChangeState(player.playerStatesManager.attackStartup);
            return;
        }
        if (moveInput == "5")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.idleState);
            return;
        }
        if (moveInput == "4")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.standBlockingState);
            return;
        }
        if (moveInput == "1")
        {
            playerStateMachine.ChangeState(player.playerStatesManager.crouchBlockingState);
            return;
        }
        //TODO below - change the dodge input to "8*5*8" or "2*5*2" - double tap of the button - will require Input interpreter to recognise this
        if (moveInput == "8")//up, towards the screen
        {
            if (player.CheckSide() == "Left")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeLeft);
            }
            else if (player.CheckSide() == "Right")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeRight);
            }
            return;
        }
        if (moveInput == "2")//down, out of the screen
        {
            if (player.CheckSide() == "Right")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeLeft);
            }
            else if (player.CheckSide() == "Left")
            {
                playerStateMachine.ChangeState(player.playerStatesManager.dodgeRight);
            }
            return;
        }
        base.TransitionChecks();

    }
}
