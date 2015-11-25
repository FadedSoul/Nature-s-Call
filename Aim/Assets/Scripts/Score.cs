using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//Made By Danny Kruiswijk

	private int score = 0;
	private PhpSender sender;
    private Spawner spawner;
	private int timer = 0;
	private bool canTime = false;
	private Text scoreText;
	private Text waveText;
    private Text coinText;
    private Text livesText;
	private int tempWave;
    private int coins = 900;
    private int lives = 10;

	void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
		sender = GameObject.Find ("PhpSender").GetComponent<PhpSender>();
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		waveText = GameObject.Find ("WaveText").GetComponent<Text>();
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
    }

    //Lives Getter
    public int livesGetter()
    {
        return lives;
    }

    //Lives Setter
    public void livesSetter(int tempInt)
    {
        lives -= tempInt;
    }

    //Coin Getter
    public int coinGetter()
    {
        return coins;
    }
    
    //Coin Setter
    public void coinSetter(int tempInt)
    {
        coins -= tempInt;
    }

	//Score Getter
	public int scoreGetter(){
		return score;
	}

	//Add 10 score
	public void addScore10(){
		score += 10;
	}

	void Update () {
        tempWave = spawner.waveGetter();
		scoreText.text = "Score: " + score;
		waveText.text = "Wave: " + tempWave;
        coinText.text = "" + coins;
        livesText.text = "" + lives;
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