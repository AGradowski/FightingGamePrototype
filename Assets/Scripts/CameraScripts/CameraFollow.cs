using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public float a = 1;
    public float b = 1;
    public Vector3 startPosition;
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
        transform.LookAt(middlePoint);
        transform.position =
        middlePoint - transform.forward.normalized
        * Vector3.Distance(player1.transform.position, player2.transform.position)
        * a
        + b * transform.forward.normalized;
    }
}
