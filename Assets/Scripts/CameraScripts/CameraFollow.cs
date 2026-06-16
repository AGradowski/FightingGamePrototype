using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public float a = 1;
    public float b = 0;
    public Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = GameObject.Find(Names.PLAYER1);
        player2 = GameObject.Find(Names.PLAYER2);
        Vector3 middlePoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        middlePoint.y = 0;
        transform.position = middlePoint + startPosition;
        transform.LookAt(middlePoint);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 middlePoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        middlePoint.y = 0;
        transform.LookAt(middlePoint);
        transform.position = middlePoint + middlePoint.magnitude * transform.forward.normalized * a;//TODO continue
    }
}
