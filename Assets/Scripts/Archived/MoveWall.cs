using UnityEngine;
using System.Collections;

public class MoveWall : MonoBehaviour
{
    public GameObject[] goWaypoints;

    public float fWallSpeed;

    private Vector2 v2WallMoveTarget;
    private Vector2 v2WallPosition;
    private Vector2 v2NextWaypointPosition;
    private Rigidbody2D rb2dWall;
    private GameObject goNextWaypoint;
    private int iCurrentWaypointIndex;

	// Use this for initialization
	void Start () 
    {
        rb2dWall = GetComponent<Rigidbody2D>();
        this.transform.position = goWaypoints[0].transform.position;
        goNextWaypoint = goWaypoints[0];
        iCurrentWaypointIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        v2WallPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        v2NextWaypointPosition = new Vector2(goNextWaypoint.transform.position.x, goNextWaypoint.transform.position.y);

        for (int i = 0; i < goWaypoints.Length; i++)
        {
            
        }

        if (Vector2.Distance(v2WallPosition, v2NextWaypointPosition) < 10f)
        {
            if (iCurrentWaypointIndex >= (goWaypoints.Length - 1))
            {
                iCurrentWaypointIndex = 0;
            }
            else
            {
                iCurrentWaypointIndex++;
            }

            goNextWaypoint = goWaypoints[iCurrentWaypointIndex];
        }

        v2WallMoveTarget = goNextWaypoint.transform.position - this.transform.position;
	}

    void FixedUpdate()
    {
        rb2dWall.velocity = v2WallMoveTarget.normalized * fWallSpeed;
    }
}
