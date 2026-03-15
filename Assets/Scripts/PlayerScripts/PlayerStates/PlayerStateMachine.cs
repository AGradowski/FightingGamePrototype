using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentPlayerState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentPlayerState = startingState;
        startingState.EnterState();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        CurrentPlayerState.EnterState();
    }

    public void SendMessageToState()
    {
    }

}
