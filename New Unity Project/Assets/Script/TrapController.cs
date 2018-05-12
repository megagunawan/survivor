using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {

		// If the bullet has collided with an enemy, destroy both the enemy and itself.
		if (other.gameObject.CompareTag("Player")) {
			Debug.Log ("Trap");
			other.gameObject.BroadcastMessage ("Trapped");
			StartCoroutine (delayDestroy());
		}


	}
	IEnumerator delayDestroy(){
		yield return new WaitForSeconds (.2f);
		Destroy (this.gameObject);		
	}
}
