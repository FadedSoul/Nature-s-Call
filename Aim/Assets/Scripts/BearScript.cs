using UnityEngine;
using System.Collections;

public class BearScript : MonoBehaviour {

	//Made by Danny Kruiswijk

	private Collider2D[] hitColliders;

	void Start () {

	}

	void Update () {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
		if(hitColliders.Length > 0){
			//
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}