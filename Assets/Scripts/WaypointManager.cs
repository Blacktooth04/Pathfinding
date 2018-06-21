using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction {UNI, BI}; // travels one way, UNI, or two ways, BI
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WaypointManager : MonoBehaviour {

    public GameObject[] waypoints; // used in follow target
    [SerializeField] Link[] links; // define which nodes connect to which, and which direction it can travel
    public Graph graph = new Graph(); // used in follow target

    // Use this for initialization
    void Start () {
        // if waypoints are found
		if (waypoints.Length > 0)
        {
            // add the waypoints manually to the graph as nodes
            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }
            // add the links manually as edges
            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2); // UNI
                if (l.dir == Link.direction.BI)
                    graph.AddEdge(l.node2, l.node1);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        graph.debugDraw();
	}
}
