using UnityEngine;

public class Debug_SetPlayerState : MonoBehaviour
{
    private Player player;
    //public string chosenState = StateNames.IDLE;
    private PlayerState state;

    public enum PossibleStates
    {
        Idle,
        StandBlocking,
        CrouchBlocking
    }

    public PossibleStates chosenState = PossibleStates.Idle;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GetComponent<Player>();
        //TODO find a better way to get the states
        switch (chosenState)
        {
            case PossibleStates.Idle:
                state = player.IdleState;
                break;
            case PossibleStates.StandBlocking:
                state = player.StandBlockingState;
                break;
            case PossibleStates.CrouchBlocking:
                state = player.CrouchBlockingState;
                break;
            default:
                state = player.IdleState;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //assuming it always needs to get back to idle at some point
        if (player.StateMachine.CurrentPlayerState.animationName == StateNames.IDLE && chosenState != PossibleStates.Idle)
        {
            switch (chosenState)
            {
                case PossibleStates.Idle:
                    state = player.IdleState;
                    break;
                case PossibleStates.StandBlocking:
                    state = player.StandBlockingState;
                    break;
                case PossibleStates.CrouchBlocking:
                    state = player.CrouchBlockingState;
                    break;
                default:
                    state = player.IdleState;
                    break;
            }

            player.StateMachine.ChangeState(state);
        }
    }
}
