using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour {
     private Transform target;
     public int moveSpeed;
     public int rotationSpeed;
	public float distance_from_target;
     
     
     // Use this for initialization
     void Start () {
		if (!isServer)
			return;
		ParticleSystem.EmissionModule em = GetComponent<ParticleSystem> ().emission;
		em.enabled = false;
     }
	public void Hitted(){
		if (!isServer)
			return;
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		ps.Emit (100);
		this.transform.Find("Ghost_White").GetComponent<Animator>().Play("ghost_die");
		GameObject.FindGameObjectWithTag ("GameUI").BroadcastMessage ("AddScore", 1);
		NetworkServer.Destroy(this.gameObject);

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
			this.transform.Find("Ghost_White").GetComponent<Animator>().Play("ghost_idle");
        }
		if(distance < distance_from_target) {
         
             //look at target/rotate
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-(target.position - transform.position)), rotationSpeed * Time.deltaTime);
         
             //move towards target
			transform.position += -transform.forward * moveSpeed * Time.deltaTime;
			this.transform.Find("Ghost_White").GetComponent<Animator>().Play("ghost_move");
     	}
     }
 }