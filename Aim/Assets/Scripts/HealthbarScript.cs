using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private Spawner spawner;
    private List<GameObject> tempHPList;
    private List<GameObject> tempEnemiesList;
    private int canRemove = 0;
    private Score score;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Main Camera").GetComponent<Score>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
        canRemove++;
        tempHPList = spawner.healthBarsGetter();
        tempEnemiesList = spawner.enemiesGetter();
        for (int i = 0; i < tempHPList.Count; i++)
        {
            Image[] image = tempHPList[i].GetComponentsInChildren<Image>();
            float tempHealth = tempEnemiesList[i].GetComponent<EnemyScript>().healthGetter();
            image[1].fillAmount = tempHealth/100;
            if (tempHealth <= 0)
            {
                tempHPList.RemoveAt(i);
                tempEnemiesList.RemoveAt(i);
                GameObject.Destroy(gameObject);
            }
            Waypoint tempNextWaypoint = tempEnemiesList[i].GetComponent<EnemyScript>().wayPointGetter();
            if (tempNextWaypoint.name == "EmptyWaypoint")
            {
                score.livesSetter(1);
                tempHPList.RemoveAt(i);
                tempEnemiesList.RemoveAt(i);
                GameObject.Destroy(gameObject);
            }
        }
        
	}
}