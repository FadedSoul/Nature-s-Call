using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Base : MonoBehaviour {

    private float _lives;
    [SerializeField]
    private Text livesText;
	// Use this for initialization
	void Start () {

        _lives = 3f;

	}
	
	// Update is called once per frame
	void Update () {

        livesText.text = "Lives: " + _lives;

        if (_lives == 0f)
        {
            Application.LoadLevel("Leaderboards");
        }
	}

    void OnTriggerEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            //_lives - 1f;
        }
    }
}
