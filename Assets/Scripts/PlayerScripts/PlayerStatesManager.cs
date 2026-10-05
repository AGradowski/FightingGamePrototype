using UnityEngine;

public class PlayerStatesManager
{
    public Player player;

    public Idle idleState { get; set; }
    public Blocking blockingState { get; set; }
    public StandBlocking standBlockingState { get; set; }
    public CrouchBlocking crouchBlockingState { get; set; }
    public HitStun hitStun { get; set; }
    public BlockStun blockStun { get; set; }
    public CrouchBlockStun crouchBlockStun { get; set; }
    public Moving movingState { get; set; }
    public AttackActive attackActive { get; set; }
    public AttackStartup attackStartup { get; set; }
    public RoundStart roundStart { get; set; }
    public DodgeLeft dodgeLeft { get; set; }
    public DodgeRight dodgeRight { get; set; }
    public KnockDown knockDown { get; set; }
    public WakeUp wakeUp { get; set; }
    public Launched launched { get; set; }
    public AttackRecovery attackRecovery { get; set; }


    public PlayerStatesManager(Player player)
    {
        idleState = new Idle(player, player.StateMachine, player.animator, StateNames.IDLE);
        blockingState = new Blocking(player, player.StateMachine, player.animator, StateNames.BLOCKING);
        standBlockingState = new StandBlocking(player, player.StateMachine, player.animator, StateNames.STAND_BLOCKING);
        crouchBlockingState = new CrouchBlocking(player, player.StateMachine, player.animator, StateNames.CROUCH_BLOCKING);
        hitStun = new HitStun(player, player.StateMachine, player.animator, StateNames.HIT_STUN);
        movingState = new Moving(player, player.StateMachine, player.animator, StateNames.MOVING);
        attackActive = new AttackActive(player, player.StateMachine, player.animator, StateNames.ATTACK);
        attackStartup = new AttackStartup(player, player.StateMachine, player.animator, StateNames.ATTACK);
        attackRecovery = new AttackRecovery(player, player.StateMachine, player.animator, StateNames.ATTACK);
        blockStun = new BlockStun(player, player.StateMachine, player.animator, StateNames.BLOCK_STUN);
        crouchBlockStun = new CrouchBlockStun(player, player.StateMachine, player.animator, StateNames.CROUCH_BLOCK_STUN);
        roundStart = new RoundStart(player, player.StateMachine, player.animator, StateNames.ROUND_START);
        dodgeLeft = new DodgeLeft(player, player.StateMachine, player.animator, StateNames.DODGE_LEFT);
        dodgeRight = new DodgeRight(player, player.StateMachine, player.animator, StateNames.DODGE_RIGHT);
        knockDown = new KnockDown(player, player.StateMachine, player.animator, StateNames.KNOCK_DOWN);
        wakeUp = new WakeUp(player, player.StateMachine, player.animator, StateNames.WAKE_UP);
        launched = new Launched(player, player.StateMachine, player.animator, StateNames.LAUNCHED);
    }
}
