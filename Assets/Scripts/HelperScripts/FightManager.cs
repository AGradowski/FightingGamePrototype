using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{

    public GameObject playerObject1, playerObject2;

    public Transform SpawnPoint1, SpawnPoint2;
    private Player player1, player2;

    public GameObject mainCamera;

    private GameObject player1ObjectInstance, player2ObjectInstance;


    #region Cinematic Timers
    public int roundStartCinematicTimer = 1;

    #endregion


    // public GameObject uiManager;




    #region roundManagement
    private int roundNumber = 0;
    private int winsP1 = 0, winsP2 = 0;
    private int roundsToWin = 2;
    private bool playerDiedFlag = false;
    private IEnumerator coroutine;

    #endregion



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Application.targetFrameRate = 60;
        Setup();

    }

    void Start()
    {

        Actions.HealthChanged(player1ObjectInstance.GetComponent<Player>());

        Actions.HealthChanged(player2ObjectInstance.GetComponent<Player>());

        Actions.PlayerDied += PlayerDied;

        RoundStart();

    }

    // Update is called once per frame
    void Update()
    {
        //check for health of players
    }

    void LateUpdate()
    {
        //add checking for flags
    }

    void Setup()
    {
        player1ObjectInstance = Instantiate(playerObject1, SpawnPoint1.position, SpawnPoint1.rotation);
        player1ObjectInstance.name = Names.PLAYER1;
        player1 = player1ObjectInstance.GetComponent<Player>();
        player2ObjectInstance = Instantiate(playerObject2, SpawnPoint2.position, SpawnPoint2.rotation);
        player2ObjectInstance.name = Names.PLAYER2;
        player2 = player2ObjectInstance.GetComponent<Player>();
        //note, the orders matters for now, only one gets the Keyboard + mouse control scheme
        // the first one above



        //player1ObjectInstance.GetComponent<Player>().SetOpponentTransform(player2ObjectInstance.transform);
        //
        //player2ObjectInstance.GetComponent<PlayerController>().SetOpponentTransform(player1ObjectInstance.transform);

        player1.mainCamera = mainCamera;



        //ayo, that can be easily changed for other camera :O
        // player2ObjectInstance.GetComponent<PlayerController>().mainCamera = mainCamera;
        player1.fightManager = gameObject;
        player2.fightManager = gameObject;
    }

    private void PlayerDied(Player player)
    {
        if (playerDiedFlag)
        {
            return;
        }
        playerDiedFlag = true;

        coroutine = CheckDeath();
        StartCoroutine(coroutine);
    }

    private IEnumerator CheckDeath()
    {
        //playerDiedFlag = true;
        yield return new WaitForEndOfFrame();
        if (player1.playerHealthManager.healthValue <= 0 && player2.playerHealthManager.healthValue <= 0)
        {
            Debug.Log("Double KO");
        }
        else if (player1.playerHealthManager.healthValue <= 0)
        {
            Debug.Log("P2 Won");
            winsP2 += 1;
            Debug.Log(winsP2);

            //setup flags
        }
        else if (player2.playerHealthManager.healthValue <= 0)
        {
            Debug.Log("P1 Won");
            winsP1 += 1;
            Debug.Log(winsP1);
        }
        RoundEnd();
    }

    private void RoundEnd()
    {
        if (winsP1 == roundsToWin)
        {
            GameEnd(player1);
        }
        else if (winsP2 == roundsToWin)
        {
            GameEnd(player2);
        }
        else
        {
            player1.playerHealthManager.Setup();
            player2.playerHealthManager.Setup();

            player1.transform.position = SpawnPoint1.transform.position;
            player2.transform.position = SpawnPoint2.transform.position;
            //restart
            //ui update
            //move to the center
            //blovk movement for x

        }
        RoundStart();


    }

    private void RoundStart()
    {
        roundNumber += 1;
        Debug.Log(roundNumber);
        playerDiedFlag = false;
        //Actions.RoundStart();
        StartCoroutine(RoundStartCoroutine());

        //Setup();
    }

    private void GameEnd(Player winner)
    {
        Debug.Log(winner.name + " won!");
        SceneManager.LoadScene(0);
    }

    IEnumerator RoundStartCoroutine()
    {
        player1.setToRoundStart();
        player2.setToRoundStart();
        yield return new WaitForSeconds(this.roundStartCinematicTimer);
        player1.setToIdle();
        player2.setToIdle();
    }






}
