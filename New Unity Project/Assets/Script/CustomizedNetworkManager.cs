using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomizedNetworkManager : NetworkManager {

	public Component IPAddressContainer;

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		System.Random myRandom = new System.Random();
		Vector3 playerPos ;
		playerPos.x = -200f + 400f * (float) myRandom.NextDouble ();
		playerPos.y = 4f;
		playerPos.z = -200f + 400f * (float) myRandom.NextDouble ();
		GameObject player = (GameObject)Instantiate(playerPrefab, playerPos, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

	public void PublicCreateServer()
	{
		networkAddress = IPAddressContainer.GetComponent<Text>().text;
		client = StartClient();
	}
}
