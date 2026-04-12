using UnityEngine;

public class Debug_SetPlayerState : MonoBehaviour
{
    private Player player;
    //public string chosenState = StateNames.IDLE;
    private PlayerState state;
    private InputInterpreterDebug inputInterpreterDebug;

    public enum PossibleStates
    {
        Idle,
        StandBlocking,
        CrouchBlocking
    }

    public PossibleStates chosenState = PossibleStates.Idle;
    private PossibleStates prevState;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GetComponent<Player>();
        inputInterpreterDebug = GetComponent<InputInterpreterDebug>();
        //TODO find a better way to get the states
        switch (chosenState)
        {
            case PossibleStates.Idle:
                state = player.IdleState;
                inputInterpreterDebug.setDebugMovementInput("5");

                break;
            case PossibleStates.StandBlocking:
                state = player.StandBlockingState;
                inputInterpreterDebug.setDebugMovementInput("4");

                break;
            case PossibleStates.CrouchBlocking:
                state = player.CrouchBlockingState;
                inputInterpreterDebug.setDebugMovementInput("1");

                break;
            default:
                state = player.IdleState;
                inputInterpreterDebug.setDebugMovementInput("5");
                break;
        }
        prevState = chosenState;

    }

    // Update is called once per frame
    void Update()
    {
        if (chosenState != prevState)
        {


            //assuming it always needs to get back to idle at some point
            switch (chosenState)
            {
                case PossibleStates.Idle:
                    state = player.IdleState;
                    inputInterpreterDebug.setDebugMovementInput("5");
                    break;
                case PossibleStates.StandBlocking:
                    state = player.StandBlockingState;
                    inputInterpreterDebug.setDebugMovementInput("4");
                    break;
                case PossibleStates.CrouchBlocking:
                    state = player.CrouchBlockingState;
                    inputInterpreterDebug.setDebugMovementInput("1");
                    break;
                default:
                    state = player.IdleState;
                    inputInterpreterDebug.setDebugMovementInput("5");
                    break;
            }
            prevState = chosenState;
            player.StateMachine.ChangeState(state);
        }
    }
}

