
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Player player; //how it is different than rigidbody? Tutorial uses rigid body, need to be careful

    private Vector2 movementVector = new Vector2(0, 0);
    private Vector3 velocity = new Vector3(0, 0, 0);
    public float maxYVelocity = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        //Vector3 firstMove = new Vector2(1, 0).x * player.player_body.transform.forward;
        //player.player_body.Move(firstMove * Time.deltaTime);
    }

    public virtual void MovePlayer()
    {
        string input = player.inputInterpreter.GetMovementInput();
        movementVector = new Vector2(0, 0);
        if (input == "6")
        {
            movementVector = new Vector2(1.0f * player.forwardSpeed, player.transform.position.y);
            //move forward
        }
        if (input == "4")
        {
            movementVector = new Vector2(-1.0f * player.backwardSpeed, player.transform.position.y);
        }

        Vector3 finalMove = movementVector.x * player.player_body.transform.forward;
        player.player_body.Move(finalMove * Time.deltaTime);
    }

    public void StopPlayer()
    {
        //player.player_body.Move(new Vector3(0, 0, 0));
        player.player_body.velocity.Set(0, 0, 0);
    }

    public void PushPlayer(float pushback, Vector3 hittingPlayerDirection)
    {
        player.player_body.Move(hittingPlayerDirection * pushback);
    }

    public void DodgeUpdate(string direction)
    {
        Vector3 otherPlayerDirection = player.other_Player.transform.position - player.transform.position;

        Vector3 dodgeDirection;

        if (direction == "Right")
        {
            //Add the particle effect
            dodgeDirection = -1 * Vector3.Cross(otherPlayerDirection, Vector3.up).normalized;//either left or right

        }
        else if (direction == "Left")
        {
            dodgeDirection = Vector3.Cross(otherPlayerDirection, Vector3.up).normalized;
            
        }
        else return;

        Vector3 finalMove = player.dodgeSpeed * dodgeDirection;
        player.player_body.Move(finalMove * Time.deltaTime);//this is intended to be used in Update, to move the player each frame.

        FixRotation();
    }

    public void FixRotation()
    {
        Vector3 target = player.other_Player.transform.position;
        target.y = player.transform.position.y;
        player.transform.LookAt(target);
    }

    public void Launch(float power)
    {

        velocity =Vector3.ClampMagnitude( Vector3.up * Mathf.Sqrt(power * -2f * Constants.gravityValue), maxYVelocity);
        
        player.player_body.Move(velocity * Time.deltaTime);
    }

    public void ApplyGravity()
    {
        velocity.y += Constants.gravityValue * Time.deltaTime;
        player.player_body.Move(velocity * Time.deltaTime);
    }

    public bool CheckIfGrounded()
    {
        return player.player_body.isGrounded;
    }
}
