using UnityEngine;
using System.Collections;

public class PathScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    private bool canclick = true;

    public bool canClickGetter()
    {
        return canclick;
    }

    void OnMouseEnter()
    {
        canclick = false;
    }
    void OnMouseExit()
    {
        canclick = true;
    }
}