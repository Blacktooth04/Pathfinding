using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to turn off the visibility of waypoints
// make sure that a tag called 'waypoints' is created
// then tag the waypoint
// also tag the follow me ball as a waypoint
public class DisableWaypointRender : MonoBehaviour {

    public GameObject[] waypoints;

    // Use this for initialization
    void Start () {
        // turn off the rendering mesh for waypoints
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); // populate array
        for (int i = 0; i < waypoints.Length; i++)
            waypoints[i].gameObject.GetComponent<Renderer>().enabled = false;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
