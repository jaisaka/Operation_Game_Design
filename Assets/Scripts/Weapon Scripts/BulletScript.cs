using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    string debug;
	float timer;
    int fireState, dmg;
    PlayerShoot pShoot;
    PlayerStats pStats;
	// Use this for initialization
	void Start () {
        pShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
        pStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        fireState = pShoot.GetFireMode();
        switch (fireState)
        {
            case 0: dmg = 20; break;
            case 1: dmg = 10; break;
            case 2: dmg = 15; break;
            default: break;
        }
		timer = 0;
		gameObject.transform.Rotate (new Vector3 (0, 0, 90));
        pStats.ReduceAmmo();
		Debug.Log (pStats.GetAmmo ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate (.2f, 0, 0);
		timer += Time.deltaTime;
		if (timer > 2) 
		{
			GameObject.Destroy (gameObject);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "Enemies") 
		{
			try 
			{
				collision.gameObject.GetComponent<EnemyStats> ().TakeDamage (dmg);
				collision.gameObject.GetComponentInChildren<EnemyRadius>().SetTriggered(true);
				Debug.Log ("Damaged enemy for: " + dmg);
				GameObject.Destroy (gameObject);
			} catch (Exception e) {
				debug += "\n" + e;
			}
		}
		if (collision.tag != "Player" && collision.tag != "EnemyRadius") {
			GameObject.Destroy (gameObject);
		}

    }
}
