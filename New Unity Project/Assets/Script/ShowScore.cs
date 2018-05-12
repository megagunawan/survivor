using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScore : MonoBehaviour {
	private Text text;
	// Use this for initialization
	private string display_string;
	private int healthUI;
	private int score;
	private bool dead;
	void Start () {
		text = this.gameObject.transform.Find("Text").GetComponent<Text> ();
		display_string = "Welcome to Hunger Game";
		text.text = display_string;
		healthUI = 100;
		score = 0;
		dead = false;
	}

	void AddScore(int increase_score){
		score = score + increase_score;
	}
	void HealthDisplay(int health){
		healthUI = health;
	}
	void Dead(){
		dead = true;
	}
	// Update is called once per frame
	void Update () {
		display_string = "Welcome to Hunger Game, you have killed: "+score.ToString() + " and your health is: "+healthUI.ToString();
		if (OVRInput.GetDown (OVRInput.Button.Two)) {
			display_string = "Using touchpad to move around and press trigger to shoot!!";
		}
		if (dead) {
			display_string = "GG";

		}
		text.text = display_string;

	}
}
