using UnityEngine;

public class DebugInputInterpreter : InputInterpreter
{
    public override string GetMovementInput()
    {
        // Debug.Log("Returning 4");
        return "4";
    }
}
