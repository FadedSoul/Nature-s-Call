using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BearScript : MonoBehaviour {

	//Made by Danny Kruiswijk

    public Text bText;
    private Score score;
    private int tempCoins;
    private float power = 50;

	private Collider2D[] hitColliders;

	void Start () {
        score = GameObject.Find("Main Camera").GetComponent<Score>();
	}

	void Update () {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
		if(hitColliders.Length > 0){
			//
		}
	}

    void FixedUpdate() {
        bText.text = "Lvl: " + lvl;
        tempCoins = score.coinGetter();
    }

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, 1);
	}

    private float lvl = 1f;
    private int sell = 80;

    public void PowerUp()
    {
        if (lvl == 1f)
        {
            if (tempCoins > 100)
            {
                sell = 50;
                power = 150;
                lvl = 2f;
                score.coinSetter(100);
            }
        }
        else
        {
            if (lvl == 2f)
            {
                if (tempCoins > 130)
                {
                    sell = 80;
                    power = 200;
                    lvl = 3f;
                    score.coinSetter(130);
                }
            }
            else
            {
                Debug.Log("To low money");
            }
        }

    }

    public void Sell()
    {
        Destroy(gameObject);
        score.coinSetter(-sell);
    }
}