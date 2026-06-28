using UnityEngine;

public class FrameInput
{
    public bool leftPunch;
    public bool rightPunch;
    public bool leftKick;
    public bool rightKick;
    public string moveInput;

    public FrameInput(bool LP = false, bool RP = false, bool LK = false, bool RK = false, string move = "5")
    {
        leftPunch = LP;
        rightPunch = RP;
        leftKick = LK;
        rightKick = RK;
        moveInput = move;
    }

    public void Clear()
    {
        leftPunch = false;
        rightPunch = false;
        leftKick = false;
        leftPunch = false;
        rightKick = false;
        moveInput = "5";
    }

    public string AttackToString()
    {
        string result = "";
        if (leftPunch)
        {
            result += "LP";
        }
        if (rightPunch)
        {
            if (result != "")
            {
                result += "+";
            }
            result += "RP";
        }
        if (leftKick)
        {
            if (result != "")
            {
                result += "+";
            }
            result += "LK";
        }
        if (rightKick)
        {
            if (result != "")
            {
                result += "+";
            }
            result += "RK";
        }
        return result;
    }

    public string MovementInputString()
    {
        //Debug.Log(moveInput);
        return moveInput;
    }

    public FrameInput Copy()
    {
        return new FrameInput(this.leftPunch,
                                this.rightPunch,
                                this.leftKick,
                                this.rightKick,
                                this.moveInput);
    }




}
