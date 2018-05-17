using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemySlowController : NetworkBehaviour {
	private Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public float distance_from_target;
	private int life_amount;
	// Use this for initialization
	void Start () {
		if (!isServer)
			return;
		life_amount = 3;
		ParticleSystem.EmissionModule em = GetComponent<ParticleSystem> ().emission;
		em.enabled = false;
	}
	public void Hitted(){
		if (!isServer)
			return;
		life_amount--;
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		ps.Emit (100);
		StartCoroutine (delayHittedParticle());
	}
	IEnumerator delayHittedParticle(){
		yield return new WaitForSeconds (.2f);
		if (life_amount <= 0) {
			this.transform.Find("Slime_Red").GetComponent<Animator>().Play("slime_die");
			NetworkServer.Destroy (this.gameObject);
			//GameObject.FindGameObjectWithTag ("GameUI").BroadcastMessage ("AddScore", 10);
		}

	}
	// Update is called once per frame
	void Update () {
		if (!isServer)
			return;

		if (target == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Player");
			if (go == null)
				return;
			target = go.transform;
		}

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