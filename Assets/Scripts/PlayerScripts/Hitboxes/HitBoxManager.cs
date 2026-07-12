using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public int attackIndex;
    Player player;

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
        AttackDataObject displayAttack = player.getAttackToDisplay(attackIndex);
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawSphere(displayAttack.hitBoxes[0].origin, displayAttack.hitBoxes[0].radius);
    }
}
