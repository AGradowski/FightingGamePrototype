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




    [HideInInspector] public AttackRecovery AttackRecovery { get; set; }//both for hit, whiff and block

    //public Dictionary<string, AttackDataObject> moveList; //possible improvemnt, but does not appear in editor, would require reading some files
    //for testing purposes, list will suffice

    public List<AttackDataObject> moveList;
    //public int displayAttackIndex = 0;

    public float forwardSpeed = 3f;
    public float backwardSpeed = 2f;
    public float gravityValue = 9.81f;


    #endregion

    #region Player Scripts
    [HideInInspector] public CharacterController player_body;//how it is different than rigidbody? Tutorial uses rigid body, need to be careful


    [HideInInspector] public PlayerMover playerMover;
    [HideInInspector] public PlayerAnimatorScript playerAnimatorScript;
    [HideInInspector] public PlayerAttackController playerAttackController;
    [HideInInspector] public PlayerHitManager playerHitManager;
    [HideInInspector] public HealthScript playerHealthManager;
    [HideInInspector] public PlayerComboManager playerComboManager;

    #endregion

    #region Other
    [HideInInspector] public Animator animator;
    [HideInInspector] public PlayerInput playerInput;
    [HideInInspector] public InputInterpreter inputInterpreter;
    [HideInInspector] public LayerMask targetCollisionLayer;
    [HideInInspector] public HitBoxDebuggerParent debugHitbox;

    #endregion

    #region Other Object References
    [HideInInspector] public GameObject other_Player;
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




}
