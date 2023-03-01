using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnRate;

    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;

        StartCoroutine("SpawnObstacles"); //В Unity корутины регистрируются и выполняются до первого yield с помощью метода StartCoroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // IEnumerator is for a delay with less code and less memory
    // IEnumerator there isn't a function, it's a return type.
    IEnumerator SpawnObstacles()
    {
        while(true) 
        {
            Spawn();

            GameManager.instance.UpdateScore();

            yield return new WaitForSeconds(spawnRate); 
        }
    }

    void Spawn()
    {
        int randomObstacle = Random.Range(0, obstacles.Length);
        int randomSpot = Random.Range(0, 2); // 0 - top, 1 - bottom

        spawnPosition = transform.position;

        if(randomSpot < 1)
        {
            Instantiate(obstacles[randomObstacle], spawnPosition, transform.rotation);
        }
        else
        {
            if (randomObstacle == 1)
            {
                spawnPosition.x += 1;
            }

            spawnPosition.y = -transform.position.y;

            Instantiate(obstacles[randomObstacle], spawnPosition, Quaternion.Euler(0, 0, 180));
        }
    }
}
