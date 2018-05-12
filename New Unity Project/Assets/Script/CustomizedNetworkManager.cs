using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomizedNetworkManager : NetworkManager {
	
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
}
