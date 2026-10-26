using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHistory_UI : MonoBehaviour
{
    public GameObject arrrowIconTemplate;
   // public GameObject arrrowIconTemplate;

    private List<GameObject> inputHistoryIconsListP1;
    private string lastMovement;
    private int frameCount = 0;
    public int maxIcons = 10;
    private Player p1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputHistoryIconsListP1 = new List<GameObject>();
        //inputHistoryIconsListP2 = new List<GameObject>();
        p1 = GameObject.Find(Names.PLAYER1).GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        string newMovement = p1.inputInterpreter.GetMovementInput();
        if (lastMovement != newMovement)
        {
            //NOTE - optmization - use already exisitng arrow icons, just toggle them (object pool?)

            GameObject newIcon = Instantiate(arrrowIconTemplate, gameObject.transform);
            switch(newMovement)
            {
                case "5":
                    newIcon.GetComponent<Image>().color = Color.black;
                    break;
                case "4":
                    newIcon.transform.Rotate(0, 0, 90);
                    break;
                case "2":
                    newIcon.transform.Rotate(0, 0, 180);
                    break;
                case "6":
                    newIcon.transform.Rotate(0, 0, 270);
                    break;
                case "8":
                    break;
            }
            inputHistoryIconsListP1.Add(newIcon);
            if(inputHistoryIconsListP1.Count > maxIcons)
            {
                GameObject.Destroy(inputHistoryIconsListP1[0]);
                inputHistoryIconsListP1.RemoveAt(0);
            }
            frameCount++;
        }
        else
        {
            frameCount = 0;
        }


        lastMovement = newMovement;
        


    }
}
