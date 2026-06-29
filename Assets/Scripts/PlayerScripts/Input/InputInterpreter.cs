using System.Collections.Generic;
using UnityEngine;

public class InputInterpreter : MonoBehaviour
{
    protected Player player;
    protected AttackDataObject nextAttack = null;
    protected string nextMovement = "5";
    protected float retentionCounter = 0;
    protected List<AttackDataObject> moveList;
    protected FrameInput frameInput = new FrameInput();
    protected InputBuffer inputBuffer = new InputBuffer();

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
        inputBuffer.addInput(frameInput);
        AnalyzeInput();
        frameInput.Clear();
    }

    public virtual void AnalyzeInput()
    {
        foreach (AttackDataObject attack in moveList)//make sure to usepriority queue for the inputs
        {
            //Debug.Log("Check");
            if (inputBuffer.containsMotionInput(attack.input))
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
