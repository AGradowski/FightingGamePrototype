using System.Collections.Generic;
using UnityEngine;

public class InputHistory
{
    private LinkedList<FrameInput> history;
    private int size;
    public InputHistory(int sizeOfBuffer)
    {
        history = new LinkedList<FrameInput>();
        size = sizeOfBuffer;
    }

    public void AddInput(FrameInput newInput)
    {
        history.AddLast(newInput);
        if (history.Count > size)
        {
            history.RemoveFirst();
        }
    }

    public string GetInputs()
    {
        //TODO add returning a string based on the current buffer, ignoring empty inputs?
        // so 2356 would become 236, no, instead merge same inputs, like 222333666 would be 236
        return "";
    }
}
