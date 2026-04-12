using UnityEngine;

public class PlayerHitManager : MonoBehaviour
{
    //private Player player;
    public bool _IsHit = false;

    public AttackDataObject currentAttack; //totally different attack, present in the second player, not this one. Need to 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAttackHit(AttackDataObject attack)
    {
        Debug.Log("Hit");
        //add copy of everything

        this._IsHit = true;
        //this.damage = attack.damage;
        currentAttack = Instantiate(attack);
    }

    public void ClearAttack()
    {
        this._IsHit = false;
        // this.damage = 0;
        Destroy(currentAttack);

    }
}
