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


    //USE array
    /*
    (-1,1)     (0,1)    (1,1)
    (-1,0)     (0,0)    (1,0)
    (-1,-1)    (0,-1)   (1,-1)
    */

    private Dictionary<Vector2, string> inputMapping = new Dictionary<Vector2, string>();




    //List<FrameInput> inputBuffer = new List<FrameInput>();



    void Start()
    {
        player = GetComponent<Player>();
        moveList = player.moveList;

        inputMapping.Add(Vector2.down, "2");
        inputMapping.Add(Vector2.up, "8");
        inputMapping.Add(Vector2.left, "4");
        inputMapping.Add(Vector2.right, "6");

        inputMapping.Add(Vector2.right + Vector2.up, "9");
        inputMapping.Add(Vector2.right + Vector2.down, "3");
        inputMapping.Add(Vector2.left + Vector2.up, "7");
        inputMapping.Add(Vector2.left + Vector2.down, "1");


        inputMapping.Add(Vector2.zero, "5");

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


        moveDirection = Vector2Int.RoundToInt(moveDirection);
        nextMovement = inputMapping.GetValueOrDefault(moveDirection);

        frameInput.moveInput = nextMovement;
    }






}

