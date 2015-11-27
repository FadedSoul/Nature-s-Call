using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	//Made by Danny Kruiswijk
	
	private float speed = 1;
    private float health = 100;
	public Vector2 bewegingsVector = Vector2.zero;
	private Waypoint targetWaypoint;
	private GameObject movementLine;
    private Score score;
    private GameObject lumberjackDiePrefab;

    void Start () {
        lumberjackDiePrefab = Resources.Load<GameObject>("Lumberjack_Die");
        score = GameObject.Find("Main Camera").GetComponent<Score>();
		targetWaypoint = this.FindClosestWaypoint();
	}

    public float healthGetter()
    {
        return health;
    }

    public Waypoint wayPointGetter()
    {
        return targetWaypoint;
    }

    public void healthSetter(float tempInt)
    {
        health = tempInt;
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            GameObject dieObject = (GameObject)Instantiate(lumberjackDiePrefab, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
            Invoke("destroyEnemy", 0.001f);
            score.coinSetter(-40);
            score.addScore10();
        }
        this.MoveToWaypoit(targetWaypoint);
        if (targetWaypoint == null)
        {
            Invoke("destroyEnemy", 0.001f);
        }
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

    void destroyEnemy()
    {
        GameObject.Destroy(gameObject);
    }
}