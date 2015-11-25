using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private int tempCoins;
    private Score score;
    private Camera camera;
    private bool canClick = false;
    private bool open = false;
    public GameObject panel;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            Debug.Log("hey");
            if (open)
            {
                panel.SetActive(true);
                open = false;
            }
            else { 
                if (!open) 
                {
                    panel.SetActive(false);
                    open = true;
                } 
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            canClick = true;
        }
    }
}
