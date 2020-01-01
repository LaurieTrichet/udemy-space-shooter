using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    public WaveConfig WaveConfig;

    private int currentIndex = 0;
    private float speed;

    private List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = WaveConfig.PathWayPoints;
        speed = WaveConfig.Speed;
        transform.position = waypoints[currentIndex++].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.Equals(waypoints[currentIndex].position))
        {
            currentIndex++;
            if (currentIndex == waypoints.Count)
            {
                Destroy(gameObject);
                return;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].position, speed * Time.deltaTime);
    }
}
