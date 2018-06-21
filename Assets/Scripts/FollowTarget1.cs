using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget1 : MonoBehaviour {

	Transform target;
	[SerializeField] float speed = 2.0f;
    [SerializeField] float accuracy = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;
    public GameObject waypointManager; // WaypointManager contains all the waypoints
    GameObject[] waypoints;
    GameObject currentNode;
    int currentWaypoint = 0;
    Graph graph;

	// Use this for initialization
	void Start () {
        waypoints = waypointManager.GetComponent<WaypointManager>().waypoints;
        graph = waypointManager.GetComponent<WaypointManager>().graph;
        currentNode = waypoints[0]; // start the tank here
	} // end start
	
    public void GoToLandingPad()
    {
        graph.AStar(currentNode, waypoints[7]);
        currentWaypoint = 0;
    }

    public void GoToRuinedTank()
    {
        graph.AStar(currentNode, waypoints[1]);
        currentWaypoint = 0;
    }

    public void GoToFuelPumps()
    {
        graph.AStar(currentNode, waypoints[4]);
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void LateUpdate () {
        // if there is no path or test if at the end of the path
        if (graph.getPathLength() == 0 || currentWaypoint == graph.getPathLength())
            return;

        // the node we are closest to currently
        currentNode = graph.getPathPoint(currentWaypoint);

        // if close enough to the current waypoint, move
        if (Vector3.Distance(graph.getPathPoint(currentWaypoint).transform.position, 
            transform.position) < accuracy) // if distance between current waypoint and tank are < accuracy
        {
            currentWaypoint++; // move to next waypoint
        }

        // if not at the end of path
        if (currentWaypoint < graph.getPathLength())
        {
            target = graph.getPathPoint(currentWaypoint).transform;

            // get the targets x and z position, this objects y position
            // don't want it to track the y position, because it started behaving weirdly
            // when the target was at differenet heights
            Vector3 lookAtTarget = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            Vector3 direction = lookAtTarget - this.transform.position; // get the vector3 to the target

            // rotate smoothly
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

            // move to the player
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    } // end late update
}
