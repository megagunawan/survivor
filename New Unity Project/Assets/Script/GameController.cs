using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public int numEnemies = 10;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {


	}	
	public void generateEnemy(GameObject enemyPrefab){
		float height = 1.89f;
		float rndX = Random.Range (200f, -200f);
		float rndZ = Random.Range (200f, -200f);
		GameObject NewEnemy = Instantiate (enemyPrefab, new Vector3 (rndZ, height, rndX), Quaternion.LookRotation(1 * Camera.main.transform.forward));
	}
	public void generateTrap(float x, float z, GameObject trapPrefab){
		GameObject NewTrap = Instantiate(trapPrefab, new Vector3(z,2.0f,x),Quaternion.LookRotation(1 * Camera.main.transform.forward));
	}
}