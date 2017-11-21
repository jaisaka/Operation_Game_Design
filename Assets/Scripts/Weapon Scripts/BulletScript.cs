using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
		gameObject.transform.Rotate (new Vector3 (0, 0, 90));
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate (.1f, 0, 0);
		timer += Time.deltaTime;
		if (timer > 1) 
		{
			GameObject.Destroy (gameObject);
		}
	}
}
