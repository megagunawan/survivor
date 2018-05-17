using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HittedScript : MonoBehaviour {

	public TextMesh IPAddress;
	public NetworkManager nm;

	public void Hitted(){
		nm.networkAddress = IPAddress.text;
		IPAddress.text = "Connecting";
		//SceneManager.LoadScene ("4140Proj");
		nm.client = nm.StartClient ();
	}
}
