using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	//Made by Danny Kruiswijk

	[SerializeField] private List<GameObject> prefabs;
	private List<GameObject> waveContent;
    private GameObject healtbarObject;
    private GameObject canvasObject;
    private GameObject spawnedEnemy;
    private GameObject spawnedHealthbar;
	private int wave = 1;
	private bool isWaving = false;
	private int timer = 100;
	private int i;
    private string tempName;
	
	void Start () {
        tempName = "Healthbar";
        healtbarObject = Resources.Load<GameObject>(tempName);
        waveContent = new List<GameObject>();
        canvasObject = GameObject.Find("Canvas");
	}

	public int waveGetter(){
		return wave;
	}

	void Update () {
		if (isWaving && timer == 100 && i < waveContent.Count) {
            spawnedEnemy = (GameObject)Instantiate(waveContent[i], new Vector2(transform.position.x, transform.position.y), transform.rotation);
            spawnedHealthbar = (GameObject)Instantiate(healtbarObject, new Vector3(spawnedEnemy.transform.position.x, spawnedEnemy.transform.position.y,0f), transform.rotation);
            spawnedHealthbar.transform.parent = canvasObject.transform;
            spawnedHealthbar.transform.localScale = new Vector3(44f,44f,1f);
            i++;
		}
        if (GameObject.Find("Lumberjack(Clone)"))
        {
            spawnedHealthbar.transform.position = new Vector3(spawnedEnemy.transform.position.x, spawnedEnemy.transform.position.y, 0f);
        }
        //spawnedHealthbar.transform.position = new Vector3(spawnedEnemy.transform.position.x,spawnedEnemy.transform.position.y,0f);
			/*
			for(int i = 0; i < waveContent.Count; i++){
				Debug.Log("Test");
				StartCoroutine(Wait());
				//InvokeRepeating
				GameObject spawnedEnemy = (GameObject)Instantiate(waveContent[i], new Vector2(transform.position.x,transform.position.y),transform.rotation);
			}
			isWaving = false;
			*/
		timer--;
		if(timer < 0){
			timer = 100;
		}
	}

	public void nextWave(){
		if(!isWaving){
			isWaving = true;
			switch(wave){
			case 1:
				waveContent.AddRange (new GameObject[]{Resources.Load <GameObject>("Lumberjack"),Resources.Load <GameObject>("Lumberjack"),Resources.Load <GameObject>("Lumberjack")});
				break;
			case 2:
				break;
			}
		}
	}

	void spawnWave(){
		for(int i = 0; i < waveContent.Count; i++){
			Debug.Log("Test");
			GameObject spawnedEnemy = (GameObject)Instantiate(waveContent[i], new Vector2(transform.position.x,transform.position.y),transform.rotation);
		}
	}
	/*
	IEnumerator Wait(){
		yield return new WaitForSeconds(2);
	}
	*/
}
