using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//Made By Danny Kruiswijk

	private int score = 0;
	private PhpSender sender;
	private int timer = 0;
	private bool canTime = false;

	void Start () {
		sender = GameObject.Find ("PhpSender").GetComponent<PhpSender>();
	}

	//Getter
	public int scoreGetter(){
		return score;
	}

	//Add 10 score
	public void addScore10(){
		score += 10;
	}

	void Update () {
		if (canTime) {
			timer++;
		}
		//When game over
		if(timer > 50){
			Application.LoadLevel("Leaderboards");
		}
		if(Input.GetKeyDown("space")){
			sender.startSendingProcess();
			canTime = true;
		}
	}
}