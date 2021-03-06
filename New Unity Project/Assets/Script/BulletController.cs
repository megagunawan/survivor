﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
 
public class BulletController : NetworkBehaviour {
 
	public float maxDistance = 100f;

	//public GameObject IPAddress;
 
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
		//IPAddress.GetComponent<TextMesh>().text = "test1";

		// If the bullet has collided with an enemy, destroy both the enemy and itself.
		if (other.gameObject.CompareTag("Enemy")) {
			//IPAddress.GetComponent<TextMesh>().text = "test2";

			Debug.Log ("BulletController::OnTriggerEnter: Collided with enemy");
			other.gameObject.BroadcastMessage ("Hitted");
			NetworkServer.Destroy (gameObject);
		}

	}
}