using UnityEngine;

public class InputInterpreterDebug : InputInterpreter
{
    public override string GetMovementInput()
    {
        // Debug.Log("Returning 4");
        return "5";
    }

    public override void inputUpdate()
    {
        return;
    }
}
