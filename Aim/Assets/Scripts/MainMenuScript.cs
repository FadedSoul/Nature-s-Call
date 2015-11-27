using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	//Made by Danny Kruiswijk

	private Text text;
	private string name;

	void Awake () {
		//Making the namefield invisible on start
		GameObject.Find ("NameField").GetComponent<Image> ().enabled = false;
		GameObject.Find ("PlaceholderText").GetComponent<Text> ().enabled = false;
		text = GameObject.Find ("NameText").GetComponent<Text> ();
		text.enabled = false;

		//Preventing the gameobject from being destroyed so that I can use the variable where the name is stored later in the leaderboards
		DontDestroyOnLoad (transform.gameObject);
	}

	//Putting the input name into the string name
	void Update () {
		name = text.text;
	}

	//Getter of variable name
	public string nameGetter(){
		return name;
	}

	//Change scene after name has been entered
	public void changeScene(){
		Application.LoadLevel ("Main");
	}

	//Making the namefield visible after Start Game button has been pressed
	public void showNameField(){
		GameObject.Find ("NameField").GetComponent<Image> ().enabled = true;
		GameObject.Find ("PlaceholderText").GetComponent<Text> ().enabled = true;
		text.enabled = true;
	}

    public void howToPlay()
    {
        GameObject spawnedHowToPlayScreen = (GameObject)Instantiate(Resources.Load<GameObject>("Howtoplay"), new Vector2(0f, 0f), transform.rotation);
        Button b = GameObject.Find("Howtoplay(Clone)").GetComponentInChildren<Button>();
        b.onClick.AddListener(backButton);
    }

    public void backButton()
    {
        GameObject.Destroy(GameObject.Find("Howtoplay(Clone)"));
    }
}