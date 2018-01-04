using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    int maxHealth, currHealth, maxAmmo, currAmmo, currAmmoStored;
	string debug;
	// Use this for initialization
	void Start () {
        maxHealth = 100;
        currHealth = maxHealth;
        maxAmmo = 100;
        currAmmo = maxAmmo;
		currAmmoStored = maxAmmo;
	}
	// Update is called once per frame
	void Update () {
        if (currAmmo > maxAmmo)
        {
            currAmmo = maxAmmo;
        }
		if (currAmmoStored > maxAmmo) {
			currAmmoStored = maxAmmo;
			Debug.Log ("Ammo stored: " + currAmmoStored);
		}
		if (currHealth <= 0) 
		{
			transform.position = new Vector3 (0, 0, 0);
			currHealth = maxHealth;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		try { 
			if (other.gameObject.GetComponent<StatLootBox>().type == "ammo") {
				AddToStoredAmmo (other.gameObject.GetComponent<StatLootBox>().boost);
				GameObject.Destroy(other.gameObject);
			}
		}
		catch (Exception e) {
			debug += " " + e;
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
	public  int GetAmmoStored(){
		return currAmmoStored;
	}
    public void AddAmmo(int ammoToAdd)
    {
        currAmmo += ammoToAdd;
		currAmmoStored -= ammoToAdd;
		Debug.Log ("Ammo stored: " + currAmmoStored);
    }
	public void AddToStoredAmmo(int amountToAdd)
	{
		currAmmoStored += amountToAdd;
		Debug.Log ("Ammo stored: " + currAmmoStored);
	}
	public void TakeDamage (int damage)
	{
		currHealth -= damage;
	}
}
