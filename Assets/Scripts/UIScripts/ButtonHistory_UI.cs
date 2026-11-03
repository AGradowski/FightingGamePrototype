using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonHistory_UI : MonoBehaviour
{
    public GameObject buttonDisplayTemplate;

    private List<GameObject> inputHistoryButtonIconsListP1;
    public int maxIcons = 10;

    private Player p1;

    private string lastInput;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO MOVE to same input manager and arrows
        //Make sure it react correctly to buttons and arrows being pressed on different frames - how should I handle it?
        inputHistoryButtonIconsListP1 = new List<GameObject>();
        p1 = GameObject.Find(Names.PLAYER1).GetComponent<Player>();
        lastInput = "5";

    }

    // Update is called once per frame
    public bool ButtonUpdate(FrameInput currentFrame)
    {
        bool changed = false;
        if (lastInput != currentFrame.AttackToString()) {
            GameObject newIcon = Instantiate(buttonDisplayTemplate, gameObject.transform);
            ButtonIcon buttonGroup = newIcon.GetComponent<ButtonIcon>();

            if (currentFrame.ButtonPresent())
            {
                if (currentFrame.leftKick)
                {
                    buttonGroup.LK.SetActive(true);
                }
                if (currentFrame.rightKick)
                {
                    buttonGroup.RK.SetActive(true);
                }
                if (currentFrame.leftPunch)
                {
                    buttonGroup.LP.SetActive(true);
                }
                if (currentFrame.rightPunch)
                {
                    buttonGroup.RP.SetActive(true);
                }

            }
            //lastInput = currentFrame.AttackToString();
            inputHistoryButtonIconsListP1.Add(newIcon);
            if (inputHistoryButtonIconsListP1.Count > maxIcons)
            {
                GameObject.Destroy(inputHistoryButtonIconsListP1[0]);
                inputHistoryButtonIconsListP1.RemoveAt(0);
            }
            changed = true;

        }
        lastInput = currentFrame.AttackToString();
        Debug.Log(lastInput);
        return changed;
    }

    public void AddEmpty()
    {
        GameObject newIcon = Instantiate(buttonDisplayTemplate, gameObject.transform);
        inputHistoryButtonIconsListP1.Add(newIcon);
        if (inputHistoryButtonIconsListP1.Count > maxIcons)
        {
            GameObject.Destroy(inputHistoryButtonIconsListP1[0]);
            inputHistoryButtonIconsListP1.RemoveAt(0);
        }
    }
}
