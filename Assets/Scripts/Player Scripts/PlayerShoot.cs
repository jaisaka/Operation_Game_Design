using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShoot : MonoBehaviour {
	public GameObject bullet;
	public int fireModeIndex;
	public int gunIndex;
	public Gun[] guns;
	public int damage;
	public string gunName;
	public Sprite gSpr;
	public Gun gunny;
    PlayerStats pStats;
	bool justFired;
	float timer;
	// Use this for initialization
	void Start () {
		gunny = guns [0];
		pStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		fireModeIndex = 0;
		gunIndex = 0;
		UpdateGun (gunIndex);
		timer = 0;
		Debug.Log (guns.Length);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.V)) {
			if (fireModeIndex < gunny.fireModes.Length) {
				fireModeIndex++;
			}
			if (fireModeIndex >= gunny.fireModes.Length) {
				fireModeIndex = 0;
			}
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			if (gunIndex < guns.Length-1) {
				gunIndex++;
				UpdateGun (gunIndex);
			}
			if (gunIndex == guns.Length) {
				gunIndex = 0;
				UpdateGun (gunIndex);
			}
			fireModeIndex = 0;
		}
		if (gameObject.GetComponentInParent<Transform> ().rotation.z > 0 && gameObject.GetComponent<SpriteRenderer>().flipX!=true) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			Debug.Log ("Flipped!+");
		}   
		if(gameObject.GetComponentInParent<Transform> ().rotation.z < 0 && gameObject.GetComponent<SpriteRenderer>().flipX==true) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			Debug.Log ("Flipped!-");
		}
		if (Input.GetKeyDown (KeyCode.Space) && GetFireModeString() == "Semi-Auto" && pStats.GetAmmo() > 0 && !justFired) {
			InstantiateBullet ();
			justFired = true;
		}
		if (Input.GetKey (KeyCode.Space) && GetFireModeString() == "Full-Auto" && pStats.GetAmmo() > 0) {
			InstantiateBullet ();
		}
		if (Input.GetKeyDown (KeyCode.Space) && GetFireModeString() == "Burst" && pStats.GetAmmo() > 0) {
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
    public int GetFireModeIndex()
    {
        return fireModeIndex;
    }
	public string GetFireModeString()
	{
		string ret = "";
		ret = gunny.fireModes [GetFireModeIndex ()];
		return ret;
	}
	public int GetDamage(){
		return damage;
	}
	public void UpdateGun(int index){
		gunny = guns [gunIndex];
		damage = guns [index].damagePerShot;
		gunName = guns [index].name;
		gSpr = guns [index].gunSprite;
		gameObject.GetComponent<SpriteRenderer> ().sprite = gSpr;
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
		if (pStats.GetAmmo() <= pStats.GetMaxAmmo()) {
			pStats.AddAmmo (pStats.GetMaxAmmo () - pStats.GetAmmo ());
		}/*else {
			
		}*/
    }
	/*IEnumerator DisplayMessageForSeconds (string message, float seconds){
		
	}*/
}
