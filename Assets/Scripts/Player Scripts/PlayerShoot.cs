using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			var attackInst = Instantiate (bullet);
			attackInst.transform.SetParent (gameObject.transform);
			attackInst.transform.localPosition = new Vector3 (0, 0, 0);
			attackInst.transform.localRotation = Quaternion.Euler (0, 0, 0);
			attackInst.transform.SetParent (null);
		}
	}
}
