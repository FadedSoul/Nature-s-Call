using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	//Made by Danny Kruiswijk

	private GameObject imageObject;
	private List<string> imageName;
	private int imageNum = 0;

	void Start () {
		imageObject = GameObject.Find ("CanvasTurretImage");
		imageName = new List<string>();
		imageName.Add ("squirrel_good_version");
		imageName.Add ("beer_character");
		imageName.Add ("Moose_af");
	}

	public void LoadNextPic(bool LeftRight)
	{
		imageNum ++;
		if (imageNum > imageName.Count - 1){
			imageNum = 0;
		}
		string tempName = imageName[imageNum];
		Sprite mySprite =  Resources.Load <Sprite>(tempName);
		imageObject.GetComponent<SpriteRenderer>().sprite = mySprite;
	}

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