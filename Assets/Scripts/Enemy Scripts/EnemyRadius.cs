using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadius : MonoBehaviour {
    [SerializeField]
	bool triggered;
    
    void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (!other.gameObject.GetComponent<PlayerMovement> ().GetSneaking ()){
				Debug.Log ("Enemy is Triggered");
				triggered = true;
			}
		}
	}

	public bool GetTriggered ()
	{
		return triggered;
	}
    public void SetTriggered(bool val)
    {
        triggered = val;
    }
}
