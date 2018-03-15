using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Destroy (this.gameObject, .5f);	
	}
}
