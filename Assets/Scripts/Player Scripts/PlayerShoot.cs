using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShoot : MonoBehaviour {
	public GameObject bullet;
	public int fireModeIndex;
    PlayerStats pStats;
	bool justFired;
	float timer;
	// Use this for initialization
	void Start () {
        pStats = gameObject.GetComponent<PlayerStats>();
		fireModeIndex = 0;
		timer = 0;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (fireModeIndex < 3) {
				fireModeIndex++;
			}
			if (fireModeIndex >= 3) {
				fireModeIndex = 0;
			}
		}
		if (Input.GetKeyDown (KeyCode.Space) && fireModeIndex == 0 && pStats.GetAmmo() > 0 && !justFired) {
			InstantiateBullet ();
			justFired = true;
		}
		if (Input.GetKey (KeyCode.Space) && fireModeIndex == 1 && pStats.GetAmmo() > 0) {
			InstantiateBullet ();
		}
		if (Input.GetKeyDown (KeyCode.Space) && fireModeIndex == 2 && pStats.GetAmmo() > 0) {
            StartCoroutine(Burst());
		}
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

		if (justFired) {
			timer += Time.deltaTime;
			if (timer > .2f) {
				justFired = false;
				timer = 0;
			}
		}
	}
    void InstantiateBullet()
    {
        var attackInst = Instantiate(bullet);
        attackInst.transform.SetParent(gameObject.transform);
        attackInst.transform.localPosition = new Vector3(0, 0, 0);
        attackInst.transform.localRotation = Quaternion.Euler(0, 0, 0);
        attackInst.transform.SetParent(null);
    }
    public int GetFireMode()
    {
        return fireModeIndex;
    }
    IEnumerator Burst()
	{
		if (pStats.GetAmmo () >= 3) {
			for (int i = 0; i < 3; i++) {
				InstantiateBullet ();
				yield return new WaitForSeconds (.1f);
			}
		}else {
			for (int i = 0; i < pStats.GetAmmo(); i++){
				InstantiateBullet ();
				yield return new WaitForSeconds (.1f);
			}
		}
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
		if ((pStats.GetMaxAmmo () - pStats.GetAmmo()) <= pStats.GetAmmoStored ()) {
			pStats.AddAmmo (pStats.GetMaxAmmo () - pStats.GetAmmo ());
		}/*else {
			
		}*/
    }
	/*IEnumerator DisplayMessageForSeconds (string message, float seconds){
		
	}*/
}
