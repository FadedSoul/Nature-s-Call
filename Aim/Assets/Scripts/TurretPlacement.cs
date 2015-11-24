using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretPlacement : MonoBehaviour {

	//Made by Danny Kruiswijk

	[SerializeField] private List<GameObject> towerPrefabs;
    [SerializeField] private List<GameObject> circlePrefabs;
    private GameObject spawnedSquirrel;
    private GameObject spawnedSquirrelCircle;
    private Score score;
    private bool isSpawned = false;
	private Camera camera;
	private GameObject imageObject;
	private SpriteRenderer spriteRenderer;
    private int tempCoins;
	
	void Start () {
		camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
        score = GameObject.Find("Main Camera").GetComponent<Score>();
		imageObject = GameObject.Find ("CanvasTurretImage");
		spriteRenderer = imageObject.GetComponent<SpriteRenderer> ();
	}

    public void isSpawnedSetter(bool newBool)
    {
        isSpawned = newBool;
    }

    void Update()
    {
        tempCoins = score.coinGetter();
        if (isSpawned) {
            spawnedSquirrelCircle.transform.position = new Vector2(spawnedSquirrel.transform.position.x,spawnedSquirrel.transform.position.y);
        }
    }

	//Once the player has chosen a turret
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0)){
			switch(spriteRenderer.sprite.name){
                case "Squirrel_Img":
                    if (tempCoins >= 100)
                    {
                        spawnedSquirrel = (GameObject)Instantiate(towerPrefabs[0], camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)), transform.rotation);
                        spawnedSquirrelCircle = (GameObject)Instantiate(circlePrefabs[0], camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)), transform.rotation);
                        isSpawned = true;
                        score.coinSetter(100);
                    }
                    break;
                case "beer_character":
                    if (tempCoins >= 150)
                    {
                        Instantiate(towerPrefabs[1], camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)), transform.rotation);
                        score.coinSetter(150);
                    }
                    break;
                case "Moose_af":
                    if (tempCoins >= 200)
                    {
                        Instantiate(towerPrefabs[2], camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)), transform.rotation);
                        score.coinSetter(200);
                    }
                    break;
			}
		}
	}
}