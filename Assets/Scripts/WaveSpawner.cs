using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] WaveConfig[] waveConfigs = null;

    [SerializeField] bool isLooping = false;

    [SerializeField] GameManager gameManager = null;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves());
        } while (isLooping);
    }

    private IEnumerator SpawnWaves()
    {
        foreach (WaveConfig waveConfig in waveConfigs)
        {
            yield return StartCoroutine(PopulateWave(waveConfig));
        }
    }

    private IEnumerator PopulateWave(WaveConfig waveConfig)
    {
        float minSpawnDelta = waveConfig.TimeBetweenSpawn - waveConfig.SpawnRandomFactor;
        float maxSpawnDelta = waveConfig.TimeBetweenSpawn + waveConfig.SpawnRandomFactor;
        int numberOfEnemies = waveConfig.NumberOfEnemy;

        while (numberOfEnemies-- >= 0)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelta, maxSpawnDelta));
            SpawEnemy(waveConfig);
        }
    }

    private void SpawEnemy(WaveConfig waveConfig)
    {
        var enemyGameObject = Instantiate(waveConfig.EnemyPrefab);
        var pathing = enemyGameObject.GetComponent<EnemyPathing>();
        pathing.WaveConfig = waveConfig;
        var enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.gameManager = gameManager;
    }
}
