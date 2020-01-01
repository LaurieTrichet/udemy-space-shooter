using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] int numberOfEnemy = 10;
    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] GameObject pathPrefab = null;
    [SerializeField] float timeBetweenSpawn = 1f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float speed = 3f;

    public int NumberOfEnemy { get => numberOfEnemy; }
    public GameObject EnemyPrefab { get => enemyPrefab; }
    public List<Transform> PathWayPoints { 
        get
        {
            var array = new List<Transform>(pathPrefab.transform.childCount);
            foreach (Transform child in pathPrefab.transform) 
            {
                array.Add(child);
            }
            return array;
        }
    }
    public float TimeBetweenSpawn { get => timeBetweenSpawn; }
    public float SpawnRandomFactor { get => spawnRandomFactor; }
    public float Speed { get => speed; }
}

