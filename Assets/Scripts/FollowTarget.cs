using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public GameObject waypointManager; // WaypointManager contains all the waypoints
    GameObject[] waypoints;
    UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        waypoints = waypointManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
	} // end start
	
    public void GoToLandingPad()
    {
        agent.SetDestination(waypoints[7].transform.position);
    }

    public void GoToRuinedTank()
    {
        agent.SetDestination(waypoints[1].transform.position);
    }

    public void GoToFuelPumps()
    {
        agent.SetDestination(waypoints[4].transform.position);
    }

    // Update is called once per frame
    void LateUpdate () {

    } // end late update
}
