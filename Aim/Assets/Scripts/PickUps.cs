using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {

    private Money Money;
	// Use this for initialization
    void Start()
    {

    }
        //Money._PickUps = +1f;
        //Destroy(gameObject);
    void OnMouseDown()
    {
        Debug.Log("Pressed left click.");
    }
}
