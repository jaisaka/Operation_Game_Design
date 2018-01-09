using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	Transform playerTransform;
	float speed;
	string debug;
	public EnemyRadius enRad;
	// Use this for initialization
	void Start () 
	{
		enRad = gameObject.GetComponentInChildren<EnemyRadius> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		speed = .75f;
	}

	// Update is called once per frame
	void Update () 
	{
		if (enRad.GetTriggered()) 
		{
			transform.LookAt (playerTransform);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
			if (Vector3.Distance (transform.position, playerTransform.position) > .25) {
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			}
		}
	}
}