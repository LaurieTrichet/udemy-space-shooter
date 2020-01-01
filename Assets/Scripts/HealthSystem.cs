using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int health = 100;

    public Action hasDied;

    public void HandleHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        if (health <= 0)
        {
            hasDied();
        }
    }

}
