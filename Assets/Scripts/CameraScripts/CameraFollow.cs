using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject leftPlayer;//whose camera it is. In local, it will be player1, Online each player will have their setup
    private GameObject rightPlayer;
    private Vector3 oldP2p;
  
    public float a = 1;
    public float b = 0;
    public Vector3 startPosition;
    public float minDistance = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftPlayer = GameObject.Find(Names.PLAYER1);
        rightPlayer = GameObject.Find(Names.PLAYER2);
        Vector3 middlePoint = Vector3.Lerp(leftPlayer.transform.position, rightPlayer.transform.position, 0.5f);
        middlePoint.y = 0;
        transform.position = middlePoint + startPosition;
        oldP2p = rightPlayer.transform.position - leftPlayer.transform.position;
    }

    // LateUpdate is good for camera in 3rd person https://docs.unity3d.com/es/2018.3/Manual/ExecutionOrder.html
    void LateUpdate()
    {
        Vector3 middlePoint = Vector3.Lerp(leftPlayer.transform.position, rightPlayer.transform.position, 0.5f);
        middlePoint.y = startPosition.y;

        Vector3 p2p = rightPlayer.transform.position - leftPlayer.transform.position;
        if (Vector3.Dot(p2p, oldP2p) < 0)//changed due to the side swap, now the player to player vector will have reverse direction, and the dot operator can detect that
        {
            GameObject tmpPlayer = leftPlayer;
            leftPlayer = rightPlayer;
            rightPlayer = tmpPlayer;
            p2p = rightPlayer.transform.position - leftPlayer.transform.position;
        }
        oldP2p = p2p;

        Vector3 crossRes = Vector3.Cross(p2p, Vector3.up);
        transform.position =
        middlePoint - crossRes.normalized
        * Vector3.Distance(leftPlayer.transform.position, rightPlayer.transform.position)
        * a
        + b * crossRes.normalized;

        if (Vector3.Distance(transform.position, middlePoint) < minDistance)
        {
            transform.position = middlePoint - crossRes.normalized * minDistance;
        }

        transform.LookAt(middlePoint);
    }
}
