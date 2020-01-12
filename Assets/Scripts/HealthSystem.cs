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
        health -= damageDealer.Damage;
        healthHasChanged?.Invoke();
        if (health <= 0)
        {
            hasDied?.Invoke();
        }
    }

}
