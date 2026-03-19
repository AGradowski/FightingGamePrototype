using UnityEngine;

public class Debug_SetPlayerState : MonoBehaviour
{
    private Player player;
    public string chosenState = StateNames.IDLE;
    private PlayerState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GetComponent<Player>();
        //TODO find a better way to get the states
        switch (chosenState)
        {
            case StateNames.BLOCKING:
                state = player.BlockingState;
                break;
            case StateNames.IDLE:
                state = player.IdleState;
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
        if (player.StateMachine.CurrentPlayerState.animationName == StateNames.IDLE && chosenState != StateNames.IDLE)
        {
            switch (chosenState)
            {
                case StateNames.BLOCKING:
                    state = player.BlockingState;
                    break;
                case StateNames.IDLE:
                    state = player.IdleState;
                    break;
                default:
                    state = player.IdleState;
                    break;
            }

            player.StateMachine.ChangeState(state);
        }
    }
}
