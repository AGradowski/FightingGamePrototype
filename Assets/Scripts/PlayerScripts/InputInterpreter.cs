using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputInterpreter : MonoBehaviour
{
    private AttackDataObject nextAttack = null;
    private string nextMovement = "";


    private float inputRetentionTime = 7 / 60f; //1 out of the 60 frames per second - animation frames, not sthe pc frames
    private float retentionCounter = 0;

    private Player player;

    List<AttackDataObject> moveList;

    //input buffer
    private FrameInput frameInput = new FrameInput();//this might be needed onlt for motion input, the buffer for frames input (like in mashing scenario is cov
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

    public AttackDataObject GetNextCommand()
    {

        return nextAttack;

        //TODO rest of analysis, taking into account previous inputs
    }

    public virtual string GetMovementInput()
    {
        return nextMovement;
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

    public void inputUpdate()
    {
        //assume 60 fps, 7 frames input buffer, so I need to clear input after that, so 7/60 * second?
        if (retentionCounter > 0)
        {
            retentionCounter -= Time.deltaTime;


            //
        }
        else
        {
            //nextAttack = "";
            retentionCounter = inputRetentionTime;

            // AnalyzeInput(frameInput);
            frameInput.Clear();
            //inputBuffer.Add(frameInput);
            //frameInput = new FrameInput();



        }
        AnalyzeInput(frameInput);
        //here add the summing of all the inputs in the frame, no, change the needle of the writer to the next buffer item



    }

    void AnalyzeInput(FrameInput currentFrameInput)
    {
        string result = currentFrameInput.ToString();

        foreach (AttackDataObject attack in moveList)
        {
            if (attack.input == result)
            {
                // Debug.Log("Found attack");
                nextAttack = attack;
                return;
                //TODO add checking for similar results, for example if LP+RP does not exist, then LP should be chosen
            }
        }
        nextAttack = null;



        //TODO add checking in buffer for motion input

    }


}

