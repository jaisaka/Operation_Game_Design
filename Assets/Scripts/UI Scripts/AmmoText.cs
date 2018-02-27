using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour {
	PlayerStats pStats;
	PlayerShoot pShoot;
	Text ammoText;
	// Use this for initialization
	void Start () {
		pShoot = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<PlayerShoot> ();
		pStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		ammoText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ammoText.text = "Firemode: " + pShoot.GetFireModeString() + "\n" +  "Ammo: " + pStats.GetAmmo () + " Stored Ammo: " + pStats.GetAmmoStored () + " Max Ammo: " + pStats.GetMaxAmmo (); 
	}
}
