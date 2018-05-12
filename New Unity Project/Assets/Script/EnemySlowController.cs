using UnityEngine;
using System.Collections;
public class EnemySlowController : MonoBehaviour {
	private Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public float distance_from_target;



	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");

		target = go.transform;

	}

	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(target.transform.position, transform.position);

		if(distance > distance_from_target) {
			this.transform.Find("Slime_Red").GetComponent<Animator>().Play("slime_idle");
		}
		if(distance < distance_from_target) {

			//look at target/rotate
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-(target.position - transform.position)), rotationSpeed * Time.deltaTime);

			//move towards target
			transform.position += -transform.forward * moveSpeed * Time.deltaTime;
			this.transform.Find("Slime_Red").GetComponent<Animator>().Play("slime_move");
		}
	}
}