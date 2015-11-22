using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private Spawner spawner;
    private List<GameObject> tempHPList;
    private List<GameObject> tempEnemiesList;

	// Use this for initialization
	void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
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
        }
	}

}