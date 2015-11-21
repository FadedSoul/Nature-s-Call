using UnityEngine;
using System.Collections;

public class BearScript : MonoBehaviour {

	//Made by Danny Kruiswijk

	private Collider2D[] hitColliders;

	void Start () {

	}

	void Update () {
		hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        //Debug.Log(hitColliders);
		if(hitColliders.Length > 0){
			if(hitColliders[0].transform.position.x < transform.position.x){
				transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
			}else{
				transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			}
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}