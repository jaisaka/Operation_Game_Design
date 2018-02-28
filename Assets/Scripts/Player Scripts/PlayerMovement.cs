using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]
	PlayerStats pStats;
	float movementSpeed, xTrans, yTrans;
	Quaternion rotation;
	bool running, sneaking;
	Vector2 pos;
	Vector3 mousePos, cameraOffset;
	GameObject ImageHolder;
	public Sprite walkingImg, runningImg, sneakingImg;
	// Use this for initialization
	void Start () {
		ImageHolder = GameObject.Find ("MovementState").gameObject;
		pStats = gameObject.GetComponent<PlayerStats>();
		movementSpeed = .05f;
		pos = new Vector2 (0,0);
		cameraOffset = Camera.main.transform.position - gameObject.transform.position;
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
		/*if (pos.y > Camera.main.orthographicSize) {
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
		}*/
		transform.position = pos;
		if (Input.GetKeyDown (KeyCode.LeftShift) && pStats.GetStamina() > 0) {
			movementSpeed = .1f;
			running = true;
			ImageHolder.GetComponent<Image> ().sprite = runningImg;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) || pStats.GetStamina() < 0) {
			running = false;
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			movementSpeed = .025f;
			sneaking = true;
			ImageHolder.GetComponent<Image> ().sprite = sneakingImg;
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			sneaking = false;
		}
		if (!running && !sneaking) {
			movementSpeed = .05f;
			ImageHolder.GetComponent<Image> ().sprite = walkingImg;
		}
	}
	void LateUpdate()
	{
		Camera.main.transform.position = gameObject.transform.position + cameraOffset;
	}
	public bool GetRunning(){
		return running;
	}
	public bool GetSneaking(){
		return sneaking;
	}
}