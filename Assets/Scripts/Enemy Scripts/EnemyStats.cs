﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
	[SerializeField]
    int maxHealth, currHealth;
	float timer;
	bool justHurt;
    EnemyRadius enRad;
	// Use this for initialization
	void Start () {
        enRad = gameObject.GetComponentInChildren<EnemyRadius>();
        maxHealth = 100;
        currHealth = maxHealth;
		justHurt = false;
        StartCoroutine(RegenHealth());
		StartCoroutine (ResetJustHurt ());
	}
	
	// Update is called once per frame
	void Update () {
		if (currHealth <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
    public void TakeDamage(int dmg)
    {
        currHealth -= dmg;
		if (!justHurt)
        {
			justHurt = true;
            enRad.SetTriggered(true);
		}
    }
    IEnumerator RegenHealth()
    {
        while (true)
        {
			if (currHealth < 100 && !justHurt)
			{
                currHealth++;
				yield return new WaitForSeconds (1);
            }
            else
            {
                yield return null;
            } 
        }
    }
	IEnumerator ResetJustHurt () {
		while (true) {
			if (justHurt) {
				yield return new WaitForSeconds (5);
				justHurt = false;
			} else {
				yield return null;
			}
		}
	}
    public bool GetJustHurt()
    {
        return justHurt;
    }
}
