using UnityEngine;

public class DirectionalAttack
{
    public AttackDataObject attack;
    public Vector3 attackingPlayerForward;
    public DirectionalAttack(AttackDataObject attack, Vector3 attackingPlayerForward)
    {
        this.attack = attack;
        this.attackingPlayerForward = attackingPlayerForward;
    }
}
