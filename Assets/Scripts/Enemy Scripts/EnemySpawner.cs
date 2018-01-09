using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    GameObject player;
    Transform lookAt;
    float distance;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAt = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookAt.position);
        distance = hit.distance;
	}

    public float GetDistanceFromPlayer()
    {
        return distance;
    }
}
