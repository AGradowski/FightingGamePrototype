using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HitBoxManager : MonoBehaviour
{
    public int attackIndex;
    private Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

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


}
