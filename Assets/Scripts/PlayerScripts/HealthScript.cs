using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthValue = 100;

    public void ApplyDamage(int damage)
    {
        healthValue -= damage;
        Debug.Log(healthValue);
    }
}
