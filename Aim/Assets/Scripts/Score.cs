using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//Made By Danny Kruiswijk

	private int score = 0;
	private PhpSender sender;
	private int timer = 0;
	private bool canTime = false;
	private Text scoreText;
	private Text waveText;
    private Text coinText;
	private int wave = 1;
    private int coins = 100;

	void Start () {
		sender = GameObject.Find ("PhpSender").GetComponent<PhpSender>();
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		waveText = GameObject.Find ("WaveText").GetComponent<Text>();
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
    }

    public int coinGetter()
    {
        return coins;
    }

    public void coinSetter(int tempInt)
    {
        coins -= tempInt;
    }

	//Wave getter
	public int waveGetter(){
		return wave;
	}

	//Score getter
	public int scoreGetter(){
		return score;
	}

	//Add 10 score
	public void addScore10(){
		score += 10;
	}

	void Update () {
		scoreText.text = "Score: " + score;
		waveText.text = "Wave: " + wave;
        coinText.text = "" + coins;
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