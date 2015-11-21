using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquirrelScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private GameObject enemyObject;
    private Collider2D[] hitColliders;

    void Awake()
    {

    }

    void Update()
    {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        if (hitColliders.Length > 0)
        {
            Vector3 dir = hitColliders[hitColliders.Length-1].transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }

}