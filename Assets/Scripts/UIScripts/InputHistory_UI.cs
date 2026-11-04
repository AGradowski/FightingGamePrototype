using UnityEngine;

public class InputHistory_UI : MonoBehaviour
{
    ButtonHistory_UI buttonsManager;
    ArrowHistory_UI arrowsManager;

    Player p1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1 = GameObject.Find(Names.PLAYER1).GetComponent<Player>();
        buttonsManager = GetComponentInChildren<ButtonHistory_UI>();
        arrowsManager = GetComponentInChildren<ArrowHistory_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        FrameInput currentFrame = p1.inputInterpreter.GetFrameInput();
        bool arrowFlag = arrowsManager.ArrowUpdate(currentFrame.moveInput);
        bool buttonFlag = buttonsManager.ButtonUpdate(currentFrame);
        if (arrowFlag && !buttonFlag)
        {
            buttonsManager.AddEmpty();            
        }
        if(!arrowFlag && buttonFlag)
        {
            arrowsManager.AddEmpty();
        }
    }
}
