using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	public float maxDistance = 100f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Self-destruct if this bullet exceeds maxDistance from the camera.

		if (Vector3.Distance (transform.position, Camera.main.transform.position) > maxDistance) {
			Destroy (gameObject);
		}
	}

	// Detect collisions.
	void OnTriggerEnter(Collider other) {
		// If the bullet has collided with an enemy, destroy both the enemy and itself.
		Debug.Log(other.name);
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Hit");
			other.gameObject.BroadcastMessage ("Hitted");
			Destroy (gameObject);
		}		
	}
}