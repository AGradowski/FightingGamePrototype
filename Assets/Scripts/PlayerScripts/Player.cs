using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region State Machine Variables
    [HideInInspector] public PlayerStateMachine StateMachine { get; set; }
    [HideInInspector] public Idle IdleState { get; set; }
    [HideInInspector] public Blocking BlockingState { get; set; }
    [HideInInspector] public StandBlocking StandBlockingState { get; set; }
    [HideInInspector] public CrouchBlocking CrouchBlockingState { get; set; }
    [HideInInspector] public HitStun HitStun { get; set; }
    [HideInInspector] public BlockStun BlockStun { get; set; }
    [HideInInspector] public CrouchBlockStun CrouchBlockStun { get; set; }
    [HideInInspector] public Moving MovingState { get; set; }
    [HideInInspector] public AttackActive AttackActive { get; set; }
    [HideInInspector] public AttackStartup AttackStartup { get; set; }
    [HideInInspector] public RoundStart RoundStart { get; set; }
    [HideInInspector] public DodgeLeft DodgeLeft { get; set; }
    [HideInInspector] public DodgeRight DodgeRight { get; set; }
    [HideInInspector] public KnockDown KnockDown { get; set; }
    [HideInInspector] public WakeUp WakeUp { get; set; }
    [HideInInspector] public Launched Launched { get; set; }




    [HideInInspector] public AttackRecovery AttackRecovery { get; set; }//both for hit, whiff and block

    //public Dictionary<string, AttackDataObject> moveList; //possible improvemnt, but does not appear in editor, would require reading some files
    //for testing purposes, list will suffice

    public List<AttackDataObject> moveList;

    public float forwardSpeed = 3f;
    public float backwardSpeed = 2f;
    public float gravityValue = 9.81f;
    public float dodgeSpeed = 1f;
    public float dodgeLength = 12f;


    #endregion

    #region Player Scripts

    //TODO - add RequireComponent for all the MOnoBehaviours - it will add the component automatically

    [HideInInspector] public CharacterController player_body;//how it is different than rigidbody? Tutorial uses rigid body, need to be careful - this is just a sphere collider with extra stuff


    [HideInInspector] public PlayerMover playerMover;
    [HideInInspector] public PlayerAnimatorScript playerAnimatorScript;
    [HideInInspector] public PlayerAttackController playerAttackController;
    [HideInInspector] public PlayerHitManager playerHitManager;
    [HideInInspector] public HealthScript playerHealthManager;
    [HideInInspector] public PlayerComboManager playerComboManager;
    [HideInInspector] public PlayerParticleManager playerParticleManager;
    [HideInInspector] public HitBoxManager playerHitBoxManager;

    #endregion

    #region Other
    [HideInInspector] public Animator animator;
    [HideInInspector] public PlayerInput playerInput;
    [HideInInspector] public InputInterpreter inputInterpreter;
    [HideInInspector] public LayerMask targetCollisionLayer;
    [HideInInspector] public HitBoxDebuggerParent debugHitbox;

    #endregion

    #region Other Object References
    public GameObject other_Player;
    public GameObject mainCamera;
    public GameObject fightManager;

    [HideInInspector] public AttackDataObject currentAttack = null;


    #endregion

    #region Player Fields
    [HideInInspector] public int playerID = -1;
    [HideInInspector] public bool roundReady = false;
    #endregion



    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player_body = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerMover = GetComponent<PlayerMover>();
        playerAnimatorScript = GetComponent<PlayerAnimatorScript>();//TODO change names
        inputInterpreter = GetComponent<InputInterpreter>();
        playerAttackController = GetComponent<PlayerAttackController>();
        playerHitManager = GetComponent<PlayerHitManager>();
        playerHealthManager = GetComponent<HealthScript>();
        playerComboManager = GetComponent<PlayerComboManager>();
        playerParticleManager = GetComponent<PlayerParticleManager>();
        playerHitBoxManager = GetComponent<HitBoxManager>();

        StateMachine = GetComponent<PlayerStateMachine>();
        debugHitbox = GetComponent<HitBoxDebuggerParent>();

        IdleState = new Idle(this, StateMachine, animator, StateNames.IDLE);
        BlockingState = new Blocking(this, StateMachine, animator, StateNames.BLOCKING);
        StandBlockingState = new StandBlocking(this, StateMachine, animator, StateNames.STAND_BLOCKING);
        CrouchBlockingState = new CrouchBlocking(this, StateMachine, animator, StateNames.CROUCH_BLOCKING);
        HitStun = new HitStun(this, StateMachine, animator, StateNames.HIT_STUN);
        MovingState = new Moving(this, StateMachine, animator, StateNames.MOVING);
        AttackActive = new AttackActive(this, StateMachine, animator, StateNames.ATTACK);
        AttackStartup = new AttackStartup(this, StateMachine, animator, StateNames.ATTACK);
        AttackRecovery = new AttackRecovery(this, StateMachine, animator, StateNames.ATTACK);
        BlockStun = new BlockStun(this, StateMachine, animator, StateNames.BLOCK_STUN);
        CrouchBlockStun = new CrouchBlockStun(this, StateMachine, animator, StateNames.CROUCH_BLOCK_STUN);
        RoundStart = new RoundStart(this, StateMachine, animator, StateNames.ROUND_START);
        DodgeLeft = new DodgeLeft(this, StateMachine, animator, StateNames.DODGE_LEFT);
        DodgeRight = new DodgeRight(this, StateMachine, animator, StateNames.DODGE_RIGHT);
        KnockDown = new KnockDown(this, StateMachine, animator, StateNames.KNOCK_DOWN);
        WakeUp  = new WakeUp(this, StateMachine, animator, StateNames.WAKE_UP);
        Launched = new Launched(this, StateMachine, animator, StateNames.LAUNCHED);

        RaycastHit groundHit;
        if (Physics.Raycast(player_body.transform.position, Vector3.down, out groundHit, Mathf.Infinity, LayerMask.GetMask(Names.GROUND_LAYER)))
        {
            Debug.DrawRay(player_body.transform.position, Vector3.down * groundHit.distance, Color.yellow, 100f);
            transform.position = groundHit.point;
            player_body.transform.position = groundHit.point;
        }
        else
        {
            Debug.DrawRay(player_body.transform.position, Vector3.down * 1000, Color.white, 100f);
        }

        StateMachine.Initialize(RoundStart);
    }

    void Start()
    {
        if (this.name == Names.PLAYER1)
        {
            other_Player = GameObject.Find(Names.PLAYER2);
            mainCamera = GameObject.Find(Names.PLAYER1_CAMERA_NAME);
            targetCollisionLayer = LayerMask.GetMask(Names.LAYER_OF_PLAYER_2);
            gameObject.layer = LayerMask.NameToLayer(Names.LAYER_OF_PLAYER_1);
        }
        else if (this.name == Names.PLAYER2)
        {
            other_Player = GameObject.Find(Names.PLAYER1);
            mainCamera = GameObject.Find(Names.PLAYER2_CAMERA_NAME);
            targetCollisionLayer = LayerMask.GetMask(Names.LAYER_OF_PLAYER_1);
            gameObject.layer = LayerMask.NameToLayer(Names.LAYER_OF_PLAYER_2);
        }

        if (fightManager == null)
        {
            Debug.Log("No Manager");
            setToIdle();

        }
    }

    void Update()
    {
        inputInterpreter.inputUpdate();
        StateMachine.CurrentPlayerState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentPlayerState.PhysicsUpdate();
    }

    public void setToRoundStart()
    {
        this.roundReady = false;
        StateMachine.ChangeState(this.RoundStart);
    }

    public void setToIdle()
    {
        this.roundReady = true;
    }

    public AttackDataObject getAttackToDisplay(int index)
    {
        if (index < 0 || index >= moveList.Count)
        {
            return null;
        }
        return moveList[index];
    }

    public void SetAnimationDebug(string animationName, int frame)
    {
        return;
    }

    public string CheckSide()
    {
        Vector3 cross = Vector3.Cross(transform.forward, mainCamera.transform.forward);//in Y = 1 - the player is on the right. -1 - the player is on the left
        if(cross.y < 0)
        {
            return "Left";
        }
        return "Right";
    }
}
