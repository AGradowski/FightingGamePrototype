using UnityEngine;

public class InputInterpreterDebug : InputInterpreter
{
    public string movementInput = "5";
    public override string GetMovementInput()
    {
        // Debug.Log("Returning 4");
        return movementInput;
    }

    public override void inputUpdate()
    {
        return;
    }

    public void setDebugMovementInput(string newInput)
    {
        movementInput = newInput;
    }


}
