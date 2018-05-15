using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HittedScript : MonoBehaviour {

	public TextMesh IPAddress;

	public void Hitted(){
		NetworkManager nm = GetComponent<NetworkManager> ();
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		ps.Emit (100);
		nm.networkAddress = IPAddress.text;
		//SceneManager.LoadScene ("4140Proj");
		nm.client = nm.StartClient ();
	}
}
