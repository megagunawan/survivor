using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyBulletController : NetworkBehaviour {

	public float maxDistance = 100f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Self-destruct if this bullet exceeds maxDistance from the camera.
		if (!isServer)
			return;
		if (Vector3.Distance (transform.position, Camera.main.transform.position) > maxDistance) {
			NetworkServer.Destroy (gameObject);
		}
	}

	// Detect collisions.
	void OnTriggerEnter(Collider other) {
		// If the bullet has collided with a player, destroy both the enemy and itself.
		Debug.Log(other.name);
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Hit");
			other.gameObject.BroadcastMessage ("Hitted");
			NetworkServer.Destroy (gameObject);
		}		
	}
}