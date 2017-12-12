﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	PlayerStats pStats;
	// Use this for initialization
	void Start () {
		pStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("Hit player, damaging for 100");
			pStats.TakeDamage (100);
		}
	}
}
