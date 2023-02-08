using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // get transform of specific waypoint (pos, rot, scale)
    public Transform GetWaypoint(int index)
    {
        return transform.GetChild(index).transform;
    }

    // return number of waypoints in path
    public int GetWaypointcount()
    {
        return transform.childCount;
    }
}
