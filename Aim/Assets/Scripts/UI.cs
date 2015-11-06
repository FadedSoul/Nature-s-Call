using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	//Made by Danny Kruiswijk

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	//Sound on/off button
	public void soundButton(){
		if (AudioListener.volume == 1) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
		}
	}
}