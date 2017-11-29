using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    int maxHealth, currHealth;
    float timer;
	// Use this for initialization
	void Start () {
        maxHealth = 100;
        currHealth = maxHealth;
        StartCoroutine(RegenHealth());
	}
	
	// Update is called once per frame
	void Update () {
		if (currHealth <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
        if (currHealth < maxHealth)
        {
            timer = 0;
            timer += Time.deltaTime;
            if (timer > 1)
            {
                currHealth++;
                timer = 0;
            }
        }
	}
    public void TakeDamage(int dmg)
    {
        currHealth -= dmg;
    }
    IEnumerator RegenHealth()
    {
        while (true)
        {
            if (currHealth < 100)
            {
                currHealth++;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
    }
}
