using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputInterpreterPlayer : InputInterpreter
{


    //input buffer
    //this might be needed onlt for motion input, the buffer for frames input (like in mashing scenario is cov
    //ered by retention time)

    //what I need is to check each "Frame", what has been pressed, and then add all the buttons and directions
    // like 6 RP+LP = forward movement and both arms
    // or 4 LK+RK = back and both legs

    //what to do, need a frame input object I guess

    List<FrameInput> inputBuffer = new List<FrameInput>();



    void Awake()
    {
        player = GetComponent<Player>();
        moveList = player.moveList;

    }




    public void OnRightPunch()
    {
        frameInput.rightPunch = true;

        //TODO optimize, move to analyze input function


        //assume 60 fps, 7 frames input buffer, so I need to clear input after that, so 7/60 * second?

    }

    public void OnLeftPunch()
    {
        frameInput.leftPunch = true;
    }

    public void OnLeftKick()
    {
        frameInput.leftKick = true;
    }

    public void OnRightKick()
    {
        frameInput.rightKick = true;
    }

    public void OnMove(InputValue value)
    {
        Vector3 cross = Vector3.Cross(player.transform.forward, player.mainCamera.transform.forward);
        Vector2 moveDirection = value.Get<Vector2>() * cross.y * -1; //-1 for back, 1 for forward?

        // Debug.Log(value.Get<Vector2>());
        // Debug.Log(moveDirection.x);

        if (moveDirection.x < 0)
        {
            nextMovement = "4";
            // Debug.Log(nextMovement);
        }
        else if (moveDirection.x > 0)
        {
            nextMovement = "6";
        }
        else
        {
            nextMovement = "";//clear on change, not if i keep it
        }

    }






}

