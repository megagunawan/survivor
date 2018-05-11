using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class GunController : MonoBehaviour {

	public GameObject projectilePrefab;
	public AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	public void ShootProjectile(float projectileSpeed)
	{
		
		GameObject projectile = GameObject.Instantiate(projectilePrefab);
		projectile.transform.position = this.transform.position;

		Rigidbody rb = projectile.GetComponent<Rigidbody>();
		rb.velocity = this.transform.parent.gameObject.transform.forward * projectileSpeed;
		audio.Play ();

	}
}