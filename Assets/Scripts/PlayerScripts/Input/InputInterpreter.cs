using System.Collections.Generic;
using UnityEngine;

public class InputInterpreter : MonoBehaviour
{
    protected Player player;
    protected AttackDataObject nextAttack = null;
    protected string nextMovement = "";
    protected float inputRetentionTime = 1 / 60f; //1 out of the 60 frames per second - animation frames, not sthe pc frames
    protected float retentionCounter = 0;
    protected List<AttackDataObject> moveList;
    protected FrameInput frameInput = new FrameInput();

    protected InputHistory inputHistory = new InputHistory(12);

    public virtual string GetMovementInput()
    {
        return nextMovement;
    }
    public virtual AttackDataObject GetNextCommand()
    {

        return nextAttack;

        //TODO rest of analysis, taking into account previous inputs
    }

    public virtual void inputUpdate()
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

            AnalyzeInput(frameInput);

            // AnalyzeInput(frameInput);
            frameInput.Clear();


            //inputBuffer.Add(frameInput);
            //frameInput = new FrameInput();



        }

        //here add the summing of all the inputs in the frame, no, change the needle of the writer to the next buffer item



    }

    public virtual void AnalyzeInput(FrameInput currentFrameInput)
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
