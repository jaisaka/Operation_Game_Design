using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShoot : MonoBehaviour {
	public GameObject bullet;
	public int fireModeIndex;
    PlayerStats pStats;
	// Use this for initialization
	void Start () {
        pStats = gameObject.GetComponent<PlayerStats>();
		fireModeIndex = 0;
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
		if (Input.GetKeyDown (KeyCode.Space) && fireModeIndex == 0 && pStats.GetAmmo() > 0) {
			InstantiateBullet ();
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
        for(int i = 0; i < 3; i++)
        {
            InstantiateBullet();
            yield return new WaitForSeconds(.1f);
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        pStats.AddAmmo(pStats.GetMaxAmmo() - pStats.GetAmmo());
    }
}
