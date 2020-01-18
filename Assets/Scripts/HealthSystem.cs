using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int Health
    {
        get
        {
            return health;
        }
    }

    public Action hasDied = null;
    public Action healthHasChanged = null;

    public void HandleHit(DamageDealer damageDealer)
    {
        ComputeNewHealth(damageDealer);

        healthHasChanged?.Invoke();
        if (health <= 0)
        {
            hasDied?.Invoke();
        }
    }

    private void ComputeNewHealth(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        if (health < 0)
        {
            health = 0;
        }
    }
}
