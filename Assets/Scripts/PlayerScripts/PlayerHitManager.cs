using UnityEngine;

public class PlayerHitManager : MonoBehaviour
{
    public bool _IsHit = false;
    public bool _IsCinematicHit = false;

    public AttackDataObject hitByCurrentAttack;
    //totally different attack, present in the second player, not this one. Need to 

    public Vector3 currentEnemyForwardVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAttackHit(DirectionalAttack dAttack)
    {
        this._IsHit = true;
        this._IsCinematicHit = dAttack.attack._IsCinematicHit;
        hitByCurrentAttack = Instantiate(dAttack.attack);
        currentEnemyForwardVector = dAttack.attackingPlayerForward;
    }

    public void ClearAttack()
    {
        this._IsHit = false;
        Destroy(hitByCurrentAttack);

    }
}
