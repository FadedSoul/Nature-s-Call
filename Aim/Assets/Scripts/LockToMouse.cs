using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockToMouse : MonoBehaviour {

	//Made by Danny Kruiswijk

	private Camera camera;
    private TurretPlacement turretPlacement;
	private bool isMouseLock = true;
	private bool canClick = false;
	private Vector3 tempVector;
    private PathScript pathScript;
    private bool tempBool;
    private bool canPlace;
    private PathScript uiScript;

    void Start () {
        uiScript = GameObject.Find("LivesImage").GetComponentInChildren<PathScript>();
        pathScript = GameObject.Find("Path_right").GetComponent<PathScript>();
        turretPlacement = GameObject.Find("CanvasTurretImage").GetComponent<TurretPlacement>();
        camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
    }

	void Update () {
        tempBool = pathScript.canClickGetter();
        canPlace = uiScript.canClickGetter();
        tempVector = camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f));
		//This Fixes a bug which occured once the button was pressed
		if(Input.GetMouseButtonUp(0)){
			canClick = true;
        }
		//Locks the Tower to the mouse
		if(isMouseLock){
			transform.position = camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f));
        }
        
		//Checks if the mouse isn't hovering over the UI Menu at the Right
		if(tempVector.x < 7){
            if (canClick && tempBool && canPlace){
				if(Input.GetMouseButtonDown(0)){
					isMouseLock = false;
                    //turretPlacement.spawnedSquirrelCircleGetter
                    if (GameObject.Find("SquirrelCircle(Clone)"))
                    {
                        GameObject.Destroy(GameObject.Find("SquirrelCircle(Clone)"));
                    }
                    if (GameObject.Find("BearCircle(Clone)"))
                    {
                        GameObject.Destroy(GameObject.Find("BearCircle(Clone)"));
                    }
                    turretPlacement.isSpawnedSetter(false);
				}
			}
		}
	}
}