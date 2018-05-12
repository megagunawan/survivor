using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScore : MonoBehaviour {
	private Text text;
	// Use this for initialization
	private string display_string;
	private int score;
	void Start () {
		text = this.gameObject.GetComponent<Text> ();
		display_string = "Welcome to Hunger Game";
		text.text = display_string;
		score = 0;
	}

	void AddScore(int increase_score){
		score = score + increase_score;
	}
	// Update is called once per frame
	void Update () {
		display_string = "Welcome to Hunger Game, you have killed: "+score.ToString();
		if (OVRInput.GetDown (OVRInput.Button.Two)) {
			display_string = "Using touchpad to move around and press trigger to shoot!!";
		}
		text.text = display_string;

	}
}
