using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquirrelScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private GameObject enemyObject;
    private Collider2D[] hitColliders;
    private GameObject acorn;
    private float counter = 0f;
    private GameObject spawnedAcorn;
    private List<GameObject> allSpawnedAcorns;
    private bool isSpawned = false;
    private float speed = 0.05f;
    private float startFloat = 0f;
    private float power = 50;
    private GameObject whichEnemy;

    void Start()
    {
        allSpawnedAcorns = new List<GameObject>();
        acorn = Resources.Load<GameObject>("Acorn");
    }

    void FixedUpdate()
    {
        for (int i = 0; i < allSpawnedAcorns.Count; i++)
        {
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
        if (counter != 0)
        {
            counter--;
        }
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f,1);
        if (hitColliders.Length > 0)
        {
            whichEnemy = hitColliders[hitColliders.Length - 1].gameObject;
            if (hitColliders[0].gameObject.GetComponent<EnemyScript>() != null)
            {
                Vector3 dir = hitColliders[hitColliders.Length-1].transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if (counter <= 0)
                {
                    counter = 100f;
                    spawnedAcorn = (GameObject)Instantiate(acorn, new Vector3(transform.position.x, transform.position.y, 10f), transform.rotation);
                    allSpawnedAcorns.Add(spawnedAcorn);
                    startFloat = 0f;
                    isSpawned = true;
                }
            }
        }
    }

    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
    */

}