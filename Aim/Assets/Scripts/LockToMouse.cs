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

	void Start () {
        turretPlacement = GameObject.Find("CanvasTurretImage").GetComponent<TurretPlacement>();
        camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
    }

	void Update () {
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
            if (canClick){
				if(Input.GetMouseButtonDown(0)){
					isMouseLock = false;
                    //turretPlacement.spawnedSquirrelCircleGetter
                    GameObject.Destroy(GameObject.Find("SquirrelCircle(Clone)"));
                    turretPlacement.isSpawnedSetter(false);
				}
			}
		}
	}
}