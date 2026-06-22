using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject infiniteGroundPrefab;
    private GameObject infiniteGround;
    private GameObject player1;
    private GameObject player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infiniteGround = Instantiate(infiniteGroundPrefab);
        player1 = GameObject.Find(Names.PLAYER1);
        player2 = GameObject.Find(Names.PLAYER2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 middlePoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        middlePoint.y = infiniteGround.transform.position.y;
        infiniteGround.transform.position = middlePoint;
    }
}
