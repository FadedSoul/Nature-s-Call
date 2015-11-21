using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	//Made by Danny Kruiswijk
	
	private float speed = 1;
	
	public Vector2 bewegingsVector = Vector2.zero;
	private Waypoint targetWaypoint;
	private GameObject movementLine;
	
	void Start () {
		targetWaypoint = this.FindClosestWaypoint();
	}

	void FixedUpdate()
	{
		this.MoveToWaypoit(targetWaypoint);
	}

	void MoveToWaypoit(Waypoint waypoint)
	{
		if (Vector2.Distance(waypoint.gameObject.transform.position, this.transform.position) < 0.1)
		{
			this.targetWaypoint = waypoint.nextWaypoint;
		}
		else
		{
			Vector2 vectorRichtingWaypoint = waypoint.transform.position - this.transform.position;
			vectorRichtingWaypoint.Normalize();
			vectorRichtingWaypoint *= speed * Time.fixedDeltaTime;
			this.transform.position += new Vector3(vectorRichtingWaypoint.x, vectorRichtingWaypoint.y);
			Vector2 thispos = new Vector2(this.transform.position.x, this.transform.position.y);
			this.bewegingsVector = vectorRichtingWaypoint;
		}
	}
	
	Waypoint FindClosestWaypoint()
	{
		var enemys = GameObject.FindObjectsOfType<Waypoint>();
		if (enemys.Length > 0)
		{
			float dist = Mathf.Infinity;
			Waypoint closest = null;
			for (int i = 0; i < enemys.Length; i++)
			{
				float curDist = Vector2.Distance(enemys[i].transform.position, this.transform.position);
				if (curDist < dist)
				{
					closest = enemys[i];
					dist = curDist;
				}
			}
			return closest;
		}
		return null;
	}
}