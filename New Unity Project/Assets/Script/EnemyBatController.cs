using UnityEngine;
using System.Collections;
public class EnemyBatController : MonoBehaviour {
	public int moveSpeed;
	public int rotationSpeed;
	public float distance_from_target;
	public float attack_distance;
	public float attack_prob;
	private int life_amount;
	private Transform target;
	private Animator animator;
	private float last_attack_time;
	public GameObject projectilePrefab;

	// Use this for initialization
	void Start () {
		life_amount = 2;
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;

		animator = this.transform.Find ("Bat_Yellow").GetComponent<Animator>();
		last_attack_time = 0;

		ParticleSystem.EmissionModule em = GetComponent<ParticleSystem> ().emission;
		em.enabled = false;
	}

	public void Hitted(){
		life_amount--;
		animator.Play("bat_damaged");
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		ps.Emit (100);
		StartCoroutine (delayHittedParticle());
	}

	IEnumerator delayHittedParticle(){
		yield return new WaitForSeconds (.2f);
		if (life_amount <= 0) {
			animator.Play("bat_die");
			Destroy (this.gameObject);
			GameObject.FindGameObjectWithTag ("GameUI").BroadcastMessage ("AddScore", 8);
		}

	}

	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(target.transform.position, transform.position);

		if(distance > distance_from_target) {
			animator.Play("bat_move");
		}else {
			// Face target
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-(target.position - transform.position)), rotationSpeed * Time.deltaTime);
			if (distance < attack_distance) {
				if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("bat_attack") && Time.frameCount - last_attack_time > 120) {
					last_attack_time = Time.frameCount;
					animator.Play ("bat_move");
					// Attack target
					if (Random.Range (0, 100) < attack_prob) {
						animator.Play ("bat_attack");

						// Emit bullet
						GameObject projectile = GameObject.Instantiate(projectilePrefab);

						Debug.DrawLine (target.position, transform.position);
						Debug.Break ();
						projectile.transform.position = this.transform.position;
						Rigidbody rb = projectile.GetComponent<Rigidbody>();
						rb.velocity = (target.position - transform.position)*200;
					}
				}
			} else {
				// Move towards target
				transform.position += -transform.forward * moveSpeed * Time.deltaTime;
				animator.Play ("bat_move");
			}
		}
	}
}