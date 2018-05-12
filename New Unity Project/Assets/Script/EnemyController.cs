using UnityEngine;
using System.Collections;
public class EnemyController : MonoBehaviour {
     private Transform target;
     public int moveSpeed;
     public int rotationSpeed;
	public float distance_from_target;
     
     
     // Use this for initialization
     void Start () {
         GameObject go = GameObject.FindGameObjectWithTag("Player");
         target = go.transform;
		ParticleSystem.EmissionModule em = GetComponent<ParticleSystem> ().emission;
		em.enabled = false;
     }
	public void Hitted(){
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		ps.Emit (100);
		StartCoroutine (delayHittedParticle());
	}
	IEnumerator delayHittedParticle(){
		yield return new WaitForSeconds (.2f);
		GameObject.FindGameObjectWithTag ("GameUI").BroadcastMessage ("AddScore", 1);
		Destroy(this.gameObject);
	}
     // Update is called once per frame
     void Update () {

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