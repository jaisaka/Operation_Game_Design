using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	float movementSpeed, xTrans, yTrans;
	Vector2 pos;
	// Use this for initialization
	void Start () {
		movementSpeed = .025f;
		pos = new Vector2 (0,0);
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		xTrans = Input.GetAxis ("Horizontal") * movementSpeed;
		yTrans = Input.GetAxis ("Vertical") * movementSpeed;
		pos = new Vector2 (pos.x + xTrans, pos.y + yTrans);
		if (pos.y > Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize;
		}
		if (pos.y < -Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize;
		}
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float orthoWidth = screenRatio * Camera.main.orthographicSize;
		if (pos.x > orthoWidth) {
			pos.x = -orthoWidth;
		}
		if (pos.x < -orthoWidth) {
			pos.x = orthoWidth;
		}
		transform.position = pos;
	}
}
