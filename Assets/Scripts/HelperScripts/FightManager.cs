using UnityEngine;

public class FightManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public Transform SpawnPoint1, SpawnPoint2;

    public GameObject mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //player1 = this.gameObject.transform.GetChild(0).gameObject;
        //player2 = this.gameObject.transform.GetChild(1).gameObject;



        GameObject actual1 = Instantiate(player1, SpawnPoint1.position, SpawnPoint1.rotation);
        actual1.name = Names.PLAYER1;
        GameObject actual2 = Instantiate(player2, SpawnPoint2.position, SpawnPoint2.rotation);
        actual2.name = Names.PLAYER2;
        //note, the orders matters for now, only one gets the Keyboard + mouse control scheme
        // the first one above



        //actual1.GetComponent<Player>().SetOpponentTransform(actual2.transform);
        //
        //actual2.GetComponent<PlayerController>().SetOpponentTransform(actual1.transform);

        actual1.GetComponent<Player>().mainCamera = mainCamera;

        //ayo, that can be easily changed for other camera :O
        // actual2.GetComponent<PlayerController>().mainCamera = mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        //check for health of players
    }
}
