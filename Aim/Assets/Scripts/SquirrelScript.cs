using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SquirrelScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private GameObject enemyObject;
    private Collider2D[] hitColliders;
    private GameObject acorn;
    private float reloadTimer = 0f;
    private GameObject spawnedAcorn;
    private List<GameObject> allSpawnedAcorns;
    private float speed = 0.05f;
    private float startFloat = 0f;
    private float power = 50;
    private GameObject whichEnemy;
    private Spawner spawner;
    private int tempWave;
    public Text sText;
    private Score score;
    private int tempCoins;

    void Start()
    {
        score = GameObject.Find("Main Camera").GetComponent<Score>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        allSpawnedAcorns = new List<GameObject>();
        acorn = Resources.Load<GameObject>("Acorn");
    }

    void FixedUpdate()
    {
        sText.text = "Lvl: " + lvl;
        tempCoins = score.coinGetter();

        tempWave = spawner.waveGetter();
        for (int i = 0; i < allSpawnedAcorns.Count; i++)
        {
            if (whichEnemy == null)
            {
                GameObject.Destroy(allSpawnedAcorns[0]);
                allSpawnedAcorns.RemoveAt(0);
            }
            allSpawnedAcorns[i].transform.position = Vector2.MoveTowards(transform.position, whichEnemy.transform.position, startFloat += speed);
            if (startFloat >= 2)
            {
                GameObject.Destroy(allSpawnedAcorns[0]);
                allSpawnedAcorns.RemoveAt(0);

                EnemyScript enemyScript = whichEnemy.GetComponent<EnemyScript>();
                float tempFloat = enemyScript.healthGetter();
                enemyScript.healthSetter(tempFloat - power);
            }
        }
        if (reloadTimer != 0)
        {
            reloadTimer--;
        }
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f,1);
        if (hitColliders.Length > 0)
        {
            whichEnemy = hitColliders[hitColliders.Length - 1].gameObject;
            if (hitColliders[0].gameObject.GetComponent<EnemyScript>() != null)
            {
                //Vector3 dir = hitColliders[hitColliders.Length-1].transform.position - transform.position;
                //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if (reloadTimer <= 0)
                {
                    reloadTimer = 100f;
                    spawnedAcorn = (GameObject)Instantiate(acorn, new Vector3(transform.position.x, transform.position.y, 10f), transform.rotation);
                    allSpawnedAcorns.Add(spawnedAcorn);
                    startFloat = 0f;
                }
            }
        }
    }
    
    private float lvl = 1f;
    private int sell = 50;

    public void PowerUp()
    {
        if (lvl == 1f)
        {
            if (tempCoins > 80)
            {
                sell = 50;
                power = 100;
                lvl = 2f;
                score.coinSetter(80);
            }
        }
        else
        {
            if (lvl == 2f)
            {
                if (tempCoins > 110)
                {
                    sell = 70;
                    power = 150;
                    lvl = 3f;
                    score.coinSetter(110);
                }
            }
            else
            {
                Debug.Log("To low money");
            }
        }

    }

    public void Sell()
    {
        Destroy(gameObject);
        score.coinSetter(-sell);
    }
}