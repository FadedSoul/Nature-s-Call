using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	//Made by Danny Kruiswijk

	[SerializeField] private List<GameObject> prefabs;
    private List<GameObject>healthBars;
	private List<GameObject> waveContent;
    private List<GameObject> enemies;
    private GameObject healtbarObject;
    private GameObject canvasObject;
    private GameObject spawnedEnemy;
    private GameObject spawnedHealthbar;
    private GameObject lumberJack;
	private int wave = 1;
	private bool isWaving = false;
    private int waveSpawnCooldown = 120;
	private int timer;
	private int i;
    private string tempName;
    private bool canStartNewWave = false;
    private GameObject nextWaveText;

    void Start () {
        nextWaveText = GameObject.Find("NextWaveText");
        timer = waveSpawnCooldown;
        lumberJack = Resources.Load<GameObject>("Lumberjack");
        tempName = "Healthbar";
        healtbarObject = Resources.Load<GameObject>(tempName);
        waveContent = new List<GameObject>();
        healthBars = new List<GameObject>();
        enemies = new List<GameObject>();
        canvasObject = GameObject.Find("Canvas");
	}

    public List<GameObject> healthBarsGetter()
    {
        return healthBars;
    }

    public List<GameObject> enemiesGetter()
    {
        return enemies;
    }

    public int waveGetter(){
		return wave;
	}

    public void isWavingSetter(bool tempBool)
    {
        isWaving = tempBool;
    }

	void FixedUpdate () {
		if (isWaving && timer == waveSpawnCooldown && i < waveContent.Count) {
            canStartNewWave = true;
            spawnedEnemy = (GameObject)Instantiate(waveContent[i], new Vector3(transform.position.x, transform.position.y,0f-i), transform.rotation);
            spawnedHealthbar = (GameObject)Instantiate(healtbarObject, new Vector3(spawnedEnemy.transform.position.x, spawnedEnemy.transform.position.y,0f), transform.rotation);
            spawnedHealthbar.transform.parent = canvasObject.transform;
            enemies.Add(spawnedEnemy);
            healthBars.Add(spawnedHealthbar);
            spawnedHealthbar.transform.localScale = new Vector3(44f,44f,1f);
            i++;
		}
        if (isWaving && enemies.Count == 0 && canStartNewWave)
        {
            nextWaveText.transform.position = new Vector2(0f, 0f);
            wave++;
            isWaving = false;
            canStartNewWave = false;
        }
        if (GameObject.Find("Lumberjack(Clone)"))
        {
            for (int k = 0; k < enemies.Count; k++)
            {
                float tempHealth = enemies[k].GetComponent<EnemyScript>().healthGetter();
                if (tempHealth <= 0)
                {
                    enemies.RemoveAt(k);
                    healthBars.RemoveAt(k);
                }
                healthBars[k].transform.position = new Vector3(enemies[k].transform.position.x+0.1f, enemies[k].transform.position.y +0.66f, 0f);
            }
        }
		timer--;
		if(timer < 0){
			timer = waveSpawnCooldown;
		}
	}

    public void nextWave(){
		if(!isWaving){
            nextWaveText.transform.position = new Vector2(0f, 250f);
            i = 0;
			isWaving = true;
			switch(wave){
			case 1:
                    waveContent.Clear();
                    waveContent.AddRange (new GameObject[]{lumberJack,lumberJack,lumberJack});
                    break;
			case 2:
                    waveContent.Clear();
                    waveSpawnCooldown = 100;
                    waveContent.AddRange(new GameObject[]{lumberJack, lumberJack, lumberJack, lumberJack, lumberJack});
				    break;
            case 3:
                    waveContent.Clear();
                    waveSpawnCooldown = 80;
                    waveContent.AddRange(new GameObject[] {lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack});
                    break;
                case 4:
                    waveContent.Clear();
                    waveSpawnCooldown = 60;
                    waveContent.AddRange(new GameObject[] { lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack, lumberJack});
                    break;
                case 5:
                    waveContent.Clear();
                    waveSpawnCooldown = 20;
                    waveContent.AddRange(new GameObject[] { lumberJack, lumberJack, lumberJack, lumberJack,});
                    break;

            }
		}
	}

	void spawnWave(){
		for(int i = 0; i < waveContent.Count; i++){
			GameObject spawnedEnemy = (GameObject)Instantiate(waveContent[i], new Vector2(transform.position.x,transform.position.y),transform.rotation);
		}
	}
}