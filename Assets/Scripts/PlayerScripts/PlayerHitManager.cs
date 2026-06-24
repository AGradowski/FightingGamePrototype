using UnityEngine;

public class PlayerHitManager : MonoBehaviour
{
    //private Player player;
    public bool _IsHit = false;

    public AttackDataObject hitByCurrentAttack;
    //totally different attack, present in the second player, not this one. Need to 

    public Vector3 currentEnemyForwardVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAttackHit(DirectionalAttack dAttack)
    {
        // Debug.Log("Hit");
        //add copy of everything

        this._IsHit = true;
        //this.damage = attack.damage;
        hitByCurrentAttack = Instantiate(dAttack.attack);
        currentEnemyForwardVector = dAttack.attackingPlayerForward;
    }

    public void ClearAttack()
    {
        this._IsHit = false;
        // this.damage = 0;
        Destroy(hitByCurrentAttack);

    }
}
