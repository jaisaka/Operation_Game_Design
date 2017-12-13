using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    int maxHealth, currHealth, maxAmmo, currAmmo;
	// Use this for initialization
	void Start () {
        maxHealth = 100;
        currHealth = maxHealth;
        maxAmmo = 100;
        currAmmo = maxAmmo;
	}
	// Update is called once per frame
	void Update () {
        if (currAmmo > maxAmmo)
        {
            currAmmo = maxAmmo;
        }
		if (currHealth <= 0) 
		{
			transform.position = new Vector3 (0, 0, 0);
			currHealth = maxHealth;
		}
	}
    public void ReduceAmmo()
    {
        currAmmo--;
    }
    public int GetAmmo()
    {
        return currAmmo;
    }
    public int GetMaxAmmo()
    {
        return maxAmmo;
    }
    public void AddAmmo(int ammoToAdd)
    {
        currAmmo += ammoToAdd;
    }
	public void TakeDamage (int damage)
	{
		currHealth -= damage;
	}
}
