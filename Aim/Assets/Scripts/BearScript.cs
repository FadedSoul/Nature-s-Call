using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BearScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private float power = 50;
    private float reloadTimer = 0f;
    private GameObject whichEnemy;
    private Collider2D[] hitColliders;
    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
    }

	void Update () {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f,1);
        if (reloadTimer != 0)
        {
            reloadTimer--;
        }
        if (hitColliders.Length > 0)
        {
            whichEnemy = hitColliders[hitColliders.Length - 1].gameObject;
            if (whichEnemy.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.4f,0.4f,1f);
            }
            else
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            }
            if (hitColliders[0].gameObject.GetComponent<EnemyScript>() != null)
            {
                if (reloadTimer <= 0)
                {
                    //Hit
                    animator.SetBool("isAttacking",true);
                    reloadTimer = 80f;
                    EnemyScript enemyScript = whichEnemy.GetComponent<EnemyScript>();
                    float tempFloat = enemyScript.healthGetter();
                    enemyScript.healthSetter(tempFloat - power);
                }
            }
        }
        else
        {
            animator.SetBool("isAttacking",false);
        }

    }
}