using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
public class Enemy : BaseShip
{
    [SerializeField] float shootDelay = 1.0f;
    [SerializeField] float randomFactor = 0.5f;
    [SerializeField] int scorePoints;

    public GameManager gameManager = null;

    protected AudioManager audioManager = null;

    public override void Start()
    {
        base.Start();
        audioManager = GetComponent<AudioManager>();
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        float minSpawnDelta = shootDelay - randomFactor;
        float maxSpawnDelta = shootDelay + randomFactor;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelta, maxSpawnDelta));
            Shoot();
        }
    }

    protected override void Shoot()
    {
        base.Shoot();
        PlaySFX();
    }

    private void PlaySFX()
    {
        audioManager.Play();
    }

    protected override void OnDeath()
    {
        gameManager.AddToScore(scorePoints);
        base.OnDeath();
    }
}
