using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : MonoBehaviour {
	[SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
	private AudioSource m_AudioSource;
	private float previous_x;
	private float previous_z;
	private float new_x;
	private float new_z;
	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource>();
		previous_x = this.transform.position.x;
		previous_z = this.transform.position.z;
	}
	private void PlayFootStepAudio()
	{

		// pick & play a random footstep sound from the array,
		// excluding sound at index 0
		int n = Random.Range(1, m_FootstepSounds.Length);
		m_AudioSource.clip = m_FootstepSounds[n];
		m_AudioSource.PlayOneShot(m_AudioSource.clip);
		// move picked sound to index 0 so it's not picked next time
		m_FootstepSounds[n] = m_FootstepSounds[0];
		m_FootstepSounds[0] = m_AudioSource.clip;
	}
	// Update is called once per frame
	void Update () {
		new_z = this.transform.position.z;
		new_x = this.transform.position.x;
		if (Mathf.Abs(new_z - previous_z) > 2) {
			PlayFootStepAudio ();
			previous_x = new_x;
			previous_z = new_z;
		}else if(Mathf.Abs(new_x - previous_x) > 2){
			PlayFootStepAudio ();
			previous_x = new_x;
			previous_z = new_z;
		}
	}
}
