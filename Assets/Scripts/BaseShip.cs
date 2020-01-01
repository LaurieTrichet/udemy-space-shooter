using UnityEngine;

[RequireComponent(typeof(HealthSystem))]

public abstract class BaseShip : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] GameObject explosionPrefab = null;

    protected HealthSystem healthSystem = null;
    protected SpriteRenderer spriteRenderer = null;

    // Start is called before the first frame update
    public virtual void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSystem.hasDied = OnDeath;
    }

    protected virtual void Shoot()
    {
        SpawnLaser();
    }

    protected void SpawnLaser()
    {
        Instantiate(laserPrefab, gameObject.transform.position, Quaternion.identity);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            damageDealer.Hit();
            healthSystem.HandleHit(damageDealer);
        }
    }

    protected virtual void OnDeath()
    {
        PlayExplosionAnim();
        Destroy(gameObject);
    }

    private void PlayExplosionAnim()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform.parent);
    }
}
