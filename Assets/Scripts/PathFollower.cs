using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private WaypointPath path;          // the path we are following
    private Transform sourceWP;         // the waypoint transform we are travelling from
    private Transform targetWP;         // the waypoint transform we are travelling to
    private int targetWPIndex = 0;      // the waypoint index we are travelling to

    private float totalTimeToWP;        // the total time to get from source WP to targetWP
    private float elapsedTimeToWP = 0;  // the elapsed time (sourceWP to targetWP)
    private float speed = 3.0f;         // movement speed


    void Start()
    {
        TargetNextWaypoint(); 
    }

    void FixedUpdate()
    {
        MoveTowardsWaypoint();
    }


    // Determine what waypoint we are going to next, and set associated variables
    private void TargetNextWaypoint()
    {
        // reset the elapsed time
        elapsedTimeToWP = 0;

        // determine the source waypoint
        sourceWP = path.GetWaypoint(targetWPIndex);

        // determine the target waypoint
        // if we exhausted our waypoints, go the to first waypoint
        targetWPIndex = (targetWPIndex + 1) % path.GetWaypointcount();
        targetWP = path.GetWaypoint(targetWPIndex);

        // calculate source to target distance
        float distance = Vector3.Distance(sourceWP.position, targetWP.position);

        // calculate time to waypoint
        totalTimeToWP = distance / speed;  // t = d/v
    }

    // Travel towards the target waypoint (call this from FixedUpdate())
    private void MoveTowardsWaypoint()
    {
        // calculate the elapsed time spent on the way to this waypoint
        elapsedTimeToWP += Time.deltaTime;

        // calculate percent complete
        float elapsedTimePercentage = elapsedTimeToWP / totalTimeToWP;

        // move
        transform.position = Vector3.Lerp(sourceWP.position, targetWP.position, elapsedTimePercentage);

        // check if we've reached our waypoint (based on time). If so, target the next waypoint
        if (elapsedTimePercentage >= 1)
        {
            TargetNextWaypoint(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
