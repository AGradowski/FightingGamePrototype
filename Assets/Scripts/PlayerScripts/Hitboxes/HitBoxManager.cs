using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HitBoxManager : MonoBehaviour
{
    public int attackIndex;
    private Player player;
    public Collider[] colliderList;
    public Collider knockDownCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        colliderList = transform.GetComponentsInChildren<Collider>();
        knockDownCollider = GameObject.Find(player.gameObject.name + "/" + Names.KNOCK_DOWN_HITBOX).GetComponent<Collider>();
    }

    void OnDrawGizmosSelected()
     {
        player = GetComponent<Player>();
        AttackDataObject displayAttack = player.getAttackToDisplay(attackIndex);
        if (displayAttack == null)
        {
            Debug.Log("No attack selected!");
            return;
        }
       //TODO player.SetAnimationDebug(displayAttack.animationName, displayAttack.startupFrames + 0);

        Gizmos.color = Color.blue;
        foreach (HitBox hitBox in displayAttack.hitBoxes)
        {
            Gizmos.DrawWireSphere(hitBox.GetPositiion(player), hitBox.GetRadius());
        }

    }

    public void SetStateHurtboxes(KnockDown state)
    {
        foreach (Collider collider in colliderList)
        {
            collider.enabled = false;
        }
        knockDownCollider.enabled = true;
    }

    public void SetStateHurtboxes(Idle state)
    {
        foreach (Collider collider in colliderList)
        {
            collider.enabled = true;
        }
        knockDownCollider.enabled = false;
    }
}
