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
                nextAttack = attack;
                return;
                //TODO add checking for similar results, for example if LP+RP does not exist, then LP should be chosen
            }

        }
        nextAttack = null;
        if (inputBuffer.containsMotionInput("656"))
        {
            Debug.Log("Dash");
            nextDash = "6";
            return;
        }
        if (inputBuffer.containsMotionInput("454"))
        {
            Debug.Log("Backdash");
            nextDash = "4";
            return;
        }
        if (inputBuffer.containsMotionInput("858"))
        {
            Debug.Log("DodgeUp");
            nextDash = "8";
            return;
        }
        if (inputBuffer.containsMotionInput("252"))
        {
            Debug.Log("DodgeDown");
            nextDash = "2";
            return;
        }
        nextDash = "5";

    }

    //ALSO, check the children of this class to check for specifics


}
