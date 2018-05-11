using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject projectilePrefab;

	// Use this for initialization
	void Start () {
	}

	public void ShootProjectile(float projectileSpeed)
	{
		GameObject projectile = GameObject.Instantiate(projectilePrefab);
		projectile.transform.position = this.transform.position;

		Rigidbody rb = projectile.GetComponent<Rigidbody>();
		rb.velocity = this.transform.parent.gameObject.transform.forward * projectileSpeed;


	}
}