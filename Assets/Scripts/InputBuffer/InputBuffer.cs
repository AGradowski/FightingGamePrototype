using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputBuffer
{
    public LinkedList<FrameInput> inputHistory = new LinkedList<FrameInput>();
    public int sizeOfBuffer = 10;

    public InputBuffer()
    {
    }

    public void addInput(FrameInput input)
    {
        inputHistory.AddFirst(input.Copy());
        if (inputHistory.Count > sizeOfBuffer)
        {
            inputHistory.RemoveLast();
        }
    }

    public void clearInput()
    {
        inputHistory = new LinkedList<FrameInput>();
    }

    public bool containsMotionInput(string input)
    {
        int m = input.Length;
        int n = inputHistory.Count;
        //   Debug.Log(inputHistory.Count);
        if (m > n) return false;//just in case of edge case at the beggining

        int i = 0;
        string fullInputCheck = "";

        LinkedListNode<FrameInput> node = inputHistory.Last;

        while (node is not null)
        {
            fullInputCheck += node.Value.MovementInputString()[0];
            if (input[i] == HelpStrings.INPUT_SEPARATOR[0])
            {
                string attackInput = input.Substring(i + 1);
                if (attackInput == node.Value.AttackToString())
                {
                    return true;
                }
            }
            if (node.Value.MovementInputString()[0] == input[i])
            {
                i += 1;
                if (i == input.Length)
                {

                    return true;//found all the input parts, it is a subsequence
                }
            }


            node = node.Previous;
        }
        Debug.Log(fullInputCheck);
        return false;
    }


}
