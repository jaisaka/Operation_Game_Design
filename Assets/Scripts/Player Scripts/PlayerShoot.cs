using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public GameObject bullet;
	public int fireModeIndex;
	// Use this for initialization
	void Start () {
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
		if (Input.GetKeyDown (KeyCode.Space) && fireModeIndex == 0) {
			var attackInst = Instantiate (bullet);
			attackInst.transform.SetParent (gameObject.transform);
			attackInst.transform.localPosition = new Vector3 (0, 0, 0);
			attackInst.transform.localRotation = Quaternion.Euler (0, 0, 0);
			attackInst.transform.SetParent (null);
		}
		if (Input.GetKey (KeyCode.Space) && fireModeIndex == 1) {
			var attackInst = Instantiate (bullet);
			attackInst.transform.SetParent (gameObject.transform);
			attackInst.transform.localPosition = new Vector3 (0, 0, 0);
			attackInst.transform.localRotation = Quaternion.Euler (0, 0, 0);
			attackInst.transform.SetParent (null);	
		}
		if (Input.GetKeyDown (KeyCode.Space) && fireModeIndex == 2) {
			for (int i = 0; i < 3; i++) {
				var attackInst = Instantiate (bullet);
				attackInst.transform.SetParent (gameObject.transform);
				attackInst.transform.localPosition = new Vector3 (0, 0, 0);
				attackInst.transform.localRotation = Quaternion.Euler (0, 0, 0);
				attackInst.transform.SetParent (null);
				Wait ();
			}
		}
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (1);
	}
}
