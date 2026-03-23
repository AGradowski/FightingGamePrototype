using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script will activate the hurtbox of the attack, queue the next attack in the string, check for hits, communicate with the second player
/// </summary>


public class PlayerAttackController : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    public void ActivateHurtbox(AttackDataObject attack)
    {
        Debug.Log("Searching in:" + player.targetCollisionLayer);


        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position + attack.origin, attack.radius, player.targetCollisionLayer);

        foreach (var hitCollider in hitColliders)//TODO, there are two colliders present in the player, box collider AND CHARCTER CONTROLLER
        {
            Debug.Log("HIT");

            //Here message is used, because it is for the other player
            hitCollider.SendMessage(Messages.HIT, attack);//TODO add
        }

        //TODO add some sort of editor, to get teh exact hurtbox I want
    }

    //TODO - add seperate checking for attack type, like projectile, grab, super etc.


}
