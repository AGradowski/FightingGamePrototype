
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
        Vector3 firstMove = new Vector2(1, 0).x * player.player_body.transform.forward;
        player.player_body.Move(firstMove * Time.deltaTime);
    }


    public virtual void MovePlayer()
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
            movementVector = new Vector2(-1.0f * player.backwardSpeed, 0.0f);
        }

        Vector3 finalMove = movementVector.x * player.player_body.transform.forward;
        player.player_body.Move(finalMove * Time.deltaTime);



    }

    public void StopPlayer()
    {
        player.player_body.Move(new Vector3(0, 0, 0));
        player.player_body.velocity.Set(0, 0, 0);
    }

    public void PushPlayer(float pushback, Vector3 hittingPlayerDirection)
    {
        player.player_body.Move(hittingPlayerDirection * pushback);
    }


}
