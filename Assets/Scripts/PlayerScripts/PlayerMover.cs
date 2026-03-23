
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Player player; //how it is different than rigidbody? Tutorial uses rigid body, need to be careful

    private Vector2 movementVector = new Vector2(0, 0);
    private Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        Vector3 firstMove = new Vector2(1, 0).x * player.player_body.transform.forward;// + (velocity.y * Vector3.up);
        //Debug.Log(finalMove);

        // if (player.StateMachine.CurrentPlayerState is Moving)//TODO better solution, this is not working
        //{
        player.player_body.Move(firstMove * Time.deltaTime);
    }


    public void MovePlayer()
    {
        string input = player.inputInterpreter.GetMovementInput();
        movementVector = new Vector2(0, 0);
        if (input == "6")
        {
            movementVector = new Vector2(1.0f * player.forwardSpeed, 0.0f);
            //move forward
        }
        if (input == "4")
        {
            //Debug.Log("AAAA");
            movementVector = new Vector2(-1.0f * player.backwardSpeed, 0.0f);
        }

        /*if (player.player_body.isGrounded && player.player_body.velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += player.gravityValue * Time.deltaTime;*/

        Vector3 finalMove = movementVector.x * player.player_body.transform.forward;// + (velocity.y * Vector3.up);
        //Debug.Log(finalMove);

        // if (player.StateMachine.CurrentPlayerState is Moving)//TODO better solution, this is not working
        //{
        player.player_body.Move(finalMove * Time.deltaTime);
        //}


    }

    public void StopPlayer()
    {
        // Debug.Log("Player mover - stopping the player");
        player.player_body.Move(new Vector3(0, 0, 0));
        player.player_body.velocity.Set(0, 0, 0);
    }


}
