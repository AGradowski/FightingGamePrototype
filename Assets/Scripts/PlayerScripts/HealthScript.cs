using System;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthValue = 100;
    public int maxHealthValue = 100;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    public void ApplyDamage(int damage)
    {
        healthValue -= damage;
        Debug.Log(healthValue);
        if (Actions.HealthChanged != null)//null on no manager
        {
            Actions.HealthChanged(player);
        }
        if (healthValue <= 0)
        {
            if (Actions.PlayerDied != null)//null on no manager
            {
                Actions.PlayerDied(player);
            }
            else
            {
                healthValue = 100;//reset on no manager
            }
        }
    }

    public void Setup()
    {
        healthValue = maxHealthValue;
        Actions.HealthChanged(player);
    }
}
