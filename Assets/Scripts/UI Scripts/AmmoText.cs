using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour {
	PlayerStats pStats;
	Text ammoText;
	// Use this for initialization
	void Start () {
		pStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
		ammoText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ammoText.text = "Ammo: " + pStats.GetAmmo () + " Stored Ammo: " + pStats.GetAmmoStored () + " Max Ammo: " + pStats.GetMaxAmmo (); 
	}
}
