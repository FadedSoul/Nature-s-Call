using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretPlacement : MonoBehaviour {

	//Made by Danny Kruiswijk

	[SerializeField] private List<GameObject> prefabs;
	private Camera camera;
	private GameObject imageObject;
	private SpriteRenderer spriteRenderer;
	
	void Start () {
		camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		imageObject = GameObject.Find ("CanvasTurretImage");
		spriteRenderer = imageObject.GetComponent<SpriteRenderer> ();
	}

	//Once the player has chosen a turret
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0)){
			switch(spriteRenderer.sprite.name){
			case "squirrel_good_version":
				GameObject squirrelSpawn = (GameObject)Instantiate(prefabs[0], camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f)),transform.rotation);
				break;
			case "beer_character":
				GameObject bearSpawn = (GameObject)Instantiate(prefabs[1], camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f)),transform.rotation);
				break;
			case "Moose_af":
				GameObject mooseSpawn = (GameObject)Instantiate(prefabs[2], camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f)),transform.rotation);
				break;
			}
		}
	}
}