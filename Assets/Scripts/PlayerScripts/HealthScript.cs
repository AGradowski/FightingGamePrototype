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
        Actions.HealthChanged(player);
    }
}
