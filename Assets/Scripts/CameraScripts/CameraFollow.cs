using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public float a = 1;
    public float b = 0;
    public Vector3 startPosition;
    public float minDistance = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = GameObject.Find(Names.PLAYER1);
        player2 = GameObject.Find(Names.PLAYER2);
        Vector3 middlePoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        middlePoint.y = 0;
        transform.position = middlePoint + startPosition;
    }

    // LateUpdate is good for camera in 3rd person https://docs.unity3d.com/es/2018.3/Manual/ExecutionOrder.html
    void LateUpdate()
    {

        Vector3 middlePoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        middlePoint.y = startPosition.y;

        Vector3 crossRes = Vector3.Cross(player1.transform.forward, Vector3.up);//90 degrees from the middle

        //below would be for the caculation of d, the distance between camera, and the middle point
        //scenario - the players come closer or farther away, with min distance to be preserved
        //max distance is solved with walls, so that players CAN'T move furhter than camera allows
        //TODO - add the walls to be chlidren of the camera
        transform.position =
        middlePoint - crossRes.normalized
        * Vector3.Distance(player1.transform.position, player2.transform.position)
        * a
        + b * crossRes.normalized;


        if (Vector3.Distance(transform.position, middlePoint) < minDistance)
        {
            //if the distance is too small, just set the minDistance * normilized vector of len = 1, so it will be exact Distance (or close enough)
            transform.position = middlePoint - crossRes.normalized * minDistance;
        }

        transform.LookAt(middlePoint);
        
    }
}
