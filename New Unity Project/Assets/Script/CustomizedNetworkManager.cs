using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomizedNetworkManager : NetworkManager {

	public Component IPAddressContainer;

	public GameObject PCPlayerPrefab;

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		System.Random myRandom = new System.Random();
		Vector3 playerPos ;
		playerPos.x = -200f + 400f * (float) myRandom.NextDouble ();
		playerPos.y = 4f;
		playerPos.z = -200f + 400f * (float) myRandom.NextDouble ();
		GameObject player = null;
		Debug.Log ("Server is ready to add player with controller id: " + playerControllerId);
		if (playerControllerId != 0)
			player = (GameObject)Instantiate(playerPrefab, playerPos, Quaternion.identity);
		else
			player = (GameObject)Instantiate(PCPlayerPrefab, playerPos, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

	public override void OnClientConnect(NetworkConnection conn){
		if (conn.address.Equals("localServer")) { // Host
			ClientScene.AddPlayer (conn, 0);
		} else { // VR Client
			ClientScene.AddPlayer (conn, 1);
		}
	}

	public void PublicConnectServer()
	{
		networkAddress = IPAddressContainer.GetComponent<Text>().text;
		client = StartClient();
	}
}
