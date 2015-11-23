using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuSliders : MonoBehaviour {

    private bool Open;
    public int slide = 0;
	// Use this for initialization
    void Start()
    {
        Open = false;
    }

	
	// Update is called once per frame
	public void Slide () {
        if (Open == false)
        {
            transform.position += Vector3.left * slide;
            Open = true;
        }
        else
        {
            if (Open == true)
            {
                transform.position += Vector3.right * slide;
                Open = false;
            }
        }

	}
}
