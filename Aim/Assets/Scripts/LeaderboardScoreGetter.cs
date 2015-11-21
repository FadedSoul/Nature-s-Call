using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardScoreGetter : MonoBehaviour {

	//Made By Danny Kruiswijk
	
	private Text nameBoard;
	private Text scoreBoard;
	private GameObject nameObject;
	private GameObject scoreObject;
	private PhpSender sender;
	private List<string> scorelist = new List<string>();
	private string displayName = "";
	private string displayScore = "";
	
	void Awake () {
		sender = GameObject.Find ("PhpSender").GetComponent<PhpSender>();
		nameObject = GameObject.Find ("NameText");
		scoreObject = GameObject.Find ("ScoreText");
		nameBoard = nameObject.GetComponent<Text>();
		scoreBoard = scoreObject.GetComponent<Text>();

		//Gets the score from PHP
		scorelist = sender.getCurrentScoreList;

		//Puts the score on screen
		foreach (string score in scorelist) {
			string[] lijn = score.Split(',');
			displayName += lijn[0].ToString() + "\n";
			displayScore += lijn[1].ToString() + "\n";
		}
		nameBoard.text = displayName;
		scoreBoard.text = displayScore;
	}
}