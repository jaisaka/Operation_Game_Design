using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadius : MonoBehaviour {
    [SerializeField]
	bool triggered;
    
    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("Enemy is Triggered");
			triggered = true;
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
