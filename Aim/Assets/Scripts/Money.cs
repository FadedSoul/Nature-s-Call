using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public float _Coins;
    public float _PickUps;

    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private Text pickUpText;


	// Use this for initialization
	void Start () {
        _Coins = 0f;
        _PickUps = 0f;
	}
	
	// Update is called once per frame
    void Update()
    {
        moneyText.text = "C: " + _Coins;
        pickUpText.text = "S: " + _PickUps;
        Debug.Log(_PickUps);
    }


    
   
}
