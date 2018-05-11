using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject FastenemyPrefab;
	public GameObject SlowenemyPrefab;
	public int numEnemies = 10;

	// Use this for initialization
	void Start () {
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
			GameObject enemy = Instantiate (FastenemyPrefab, new Vector3 (rndX, height, rndZ), Quaternion.LookRotation(1 * Camera.main.transform.forward));

			//newEnemy.transform.forward = -1 * Camera.main.transform.forward;
		}
	}
}