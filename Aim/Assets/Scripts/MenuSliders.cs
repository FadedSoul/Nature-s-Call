using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuSliders : MonoBehaviour {

    private bool Open;
	// Use this for initialization
    void Start()
    {
        Open = false;
    }

	
	// Update is called once per frame
	public void Slide () {
        if (Open == false)
        {
            transform.position += Vector3.left * 4;
            Open = true;
        }
        else
        {
            if (Open == true)
            {
                transform.position += Vector3.right * 4;
                Open = false;
            }
        }

	}
}
