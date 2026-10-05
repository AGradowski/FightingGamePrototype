using System.Collections.Generic;
using UnityEngine;

public class InputInterpreter : MonoBehaviour
{
    protected Player player;
    protected AttackDataObject nextAttack = null;
    protected string nextMovement = "5";
    protected string nextDash = "5";
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
    }
    public virtual string GetSpecialMoveInput()
    {
        return nextDash;
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
            if (inputBuffer.containsMotionInput(attack.input))
            {
                if(attack.stanceName == "Attack")
                {
                    nextAttack = attack;
                    return;
                }
                if (attack.stanceName == "Move")
                {
                    nextDash = attack.moveType;
                    return;
                }

                
                //TODO add checking for similar results, for example if LP+RP does not exist, then LP should be chosen
            }

        }
        nextAttack = null;
        nextDash = "5";

    }

    //ALSO, check the children of this class to check for specifics


}
