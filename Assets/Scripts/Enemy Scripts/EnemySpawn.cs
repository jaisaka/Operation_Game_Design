using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject[] spawners;
	public GameObject enemy;
	Transform posToSpawnEnemy;
	bool canSpawn;
    void Start()
    {
		posToSpawnEnemy = spawners[GetClosestSpawn()].transform; 
		canSpawn = true;
		StartCoroutine (SpawnEnemy ());
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        posToSpawnEnemy = spawners[GetClosestSpawn()].transform;
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
	IEnumerator SpawnEnemy(){
		while (canSpawn) {
			Instantiate (enemy, posToSpawnEnemy);
			Debug.Log ("Spawned Enemy");
			yield return new WaitForSecondsRealtime (5);
		}yield return null;
	}
}
