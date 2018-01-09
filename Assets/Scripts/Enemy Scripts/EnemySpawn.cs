using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject[] spawners;
    Vector2 posToSpawnEnemy;
    void Start()
    {
        posToSpawnEnemy = new Vector2(0, 0);
    }
    // Update is called once per frame
    void Update ()
    {
        posToSpawnEnemy = spawners[GetClosestSpawn()].transform.position;
	}

    public int GetClosestSpawn()
    {
        int d = 0;
        float leastDistance = spawners[0].GetComponent<EnemySpawner>().GetDistanceFromPlayer();
        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i].GetComponent<EnemySpawner>().GetDistanceFromPlayer() < leastDistance)
            {
                leastDistance = spawners[i].GetComponent<EnemySpawner>().GetDistanceFromPlayer();
                d = i;
            }
        }
        return d;
    }
}
