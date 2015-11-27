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
    private float speed = 0.1f;
    private float startFloat = 0f;
    private float power = 15;
    private GameObject whichEnemy;
    private AudioSource throwSound;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        throwSound = GetComponent<AudioSource>();
        allSpawnedAcorns = new List<GameObject>();
        acorn = Resources.Load<GameObject>("Bullet");
    }

    void FixedUpdate()
    {
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
                AudioSource hitSound = whichEnemy.GetComponent<AudioSource>();
                hitSound.Play();
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
            if (whichEnemy.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            }
            if (hitColliders[0].gameObject.GetComponent<EnemyScript>() != null)
            {
                if (reloadTimer <= 0)
                {
                    animator.SetBool("isAttacking", true);
                    throwSound.Play();
                    reloadTimer = 20f;
                    spawnedAcorn = (GameObject)Instantiate(acorn, new Vector3(transform.position.x, transform.position.y, 10f), transform.rotation);
                    allSpawnedAcorns.Add(spawnedAcorn);
                    startFloat = 0f;
                }
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}