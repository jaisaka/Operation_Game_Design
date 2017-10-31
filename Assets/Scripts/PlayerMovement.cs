using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]
	float movementSpeed, xTrans, yTrans;
	Quaternion rotation;
	bool running;
	Vector2 pos;
	Vector3 mousePos;
	// Use this for initialization
	void Start () {
		movementSpeed = .05f;
		pos = new Vector2 (0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.mousePresent) {
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);
			rotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
			transform.rotation = rotation;
			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		}
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
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			movementSpeed = .1f;
			running = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			running = false;
		}
		if (!running) {
			movementSpeed = .05f;
		}
	}
}
