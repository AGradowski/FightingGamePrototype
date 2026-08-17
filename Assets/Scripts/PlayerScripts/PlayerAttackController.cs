using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script will activate the hurtbox of the attack, queue the next attack in the string, check for hits, communicate with the second player
/// </summary>


public class PlayerAttackController : MonoBehaviour
{
    private Player player;
    private HitBoxManager hitBoxManager;

    void Awake()
    {
        player = GetComponent<Player>();
        hitBoxManager = GetComponent<HitBoxManager>();
    }

    public bool ActivateHurtbox(AttackDataObject attack)
    {
        foreach (HitBox hitbox in attack.hitBoxes)
        {
            Collider[] hitColliders = Physics.OverlapSphere(hitbox.GetPositiion(player),
             hitbox.GetRadius(),
              player.targetCollisionLayer);//TODO check, if works for second player, forward vector not used

            if (hitColliders.Length > 0) //TODO, there are two colliders present in the player, box collider AND CHARCTER CONTROLLER
            {
                DirectionalAttack dAttack = new DirectionalAttack(attack, player.player_body.transform.forward);

                //Here message is used, because it is for the other player
                hitColliders[0].SendMessage(Messages.HIT, dAttack);
                return true;
            }
        }
        return false;
        //TODO add some sort of editor, to get teh exact hurtbox I want
    }

    //TODO - add seperate checking for attack type, like projectile, grab, super etc.


}
