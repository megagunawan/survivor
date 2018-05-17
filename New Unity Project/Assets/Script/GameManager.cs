using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

	public GameObject FastenemyPrefab;
	public GameObject SlowenemyPrefab;
	public GameObject BatenemyPrefab;
	public int numEnemies = 10;

	// Use this for initialization
	void Start () {
		if (!isServer)
			return;
		Camera main = GetComponent<Camera> ();
		main.enabled = true ;
		SpawnEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void SpawnEnemies() {


		float height = 1.89f;
		for (int i = 0; i < numEnemies; i++) {
			float rndX = Random.Range (200f, -200f);
			float rndZ = Random.Range (200f, -200f);
			Quaternion rotation = Quaternion.identity;
			Debug.Log (Camera.main);
			GameObject FastEnemy = Instantiate (FastenemyPrefab, new Vector3 (rndX, height, rndZ), Quaternion.LookRotation(1 * Camera.main.transform.forward));
			rndX = Random.Range (200f, -200f);
			rndZ = Random.Range (200f, -200f);
			GameObject SlowEnemy = Instantiate (SlowenemyPrefab, new Vector3 (rndZ, height, rndX), Quaternion.LookRotation(1 * Camera.main.transform.forward));
			//newEnemy.transform.forward = -1 * Camera.main.transform.forward;
			rndX = Random.Range (200f, -200f);
			rndZ = Random.Range (200f, -200f);
			GameObject BatEnemy = Instantiate (BatenemyPrefab, new Vector3(rndX, height, rndZ),  Quaternion.LookRotation(1 * Camera.main.transform.forward));
			NetworkServer.Spawn (FastEnemy);
			NetworkServer.Spawn (SlowEnemy);
			NetworkServer.Spawn (BatEnemy);
		}
	}
}