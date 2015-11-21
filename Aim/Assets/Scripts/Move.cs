using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }
	
}
