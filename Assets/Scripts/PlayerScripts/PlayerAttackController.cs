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

    public bool ActivateHurtbox(AttackDataObject attack)
    {
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position + attack.origin, attack.radius, player.targetCollisionLayer);

        if (hitColliders.Length > 0) //TODO, there are two colliders present in the player, box collider AND CHARCTER CONTROLLER
        {
            DirectionalAttack dAttack = new DirectionalAttack(attack, player.player_body.transform.forward);

            //Here message is used, because it is for the other player
            hitColliders[0].SendMessage(Messages.HIT, dAttack);//TODO add
            return true;
        }
        return false;

        //TODO add some sort of editor, to get teh exact hurtbox I want
    }

    //TODO - add seperate checking for attack type, like projectile, grab, super etc.


}
