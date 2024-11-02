using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private WaypointPath _waypointPath;
    [SerializeField] private float _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    private void Start()
    {
        targetNextWaypoint();       //Finds the waypoints for the platform to follow
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;     //Tracks where the platform is from the target waypoint

        float _elapsedPercentage = _elapsedTime / _timeToWaypoint;      //Will calculate how much distance the platform has traveled
        //Makes the platform move smoothly between both waypoints
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, _elapsedPercentage);

        //Makes it so if the platform has reached one waypoint it will move to the other
        if(_elapsedPercentage >= 1)
        {
            targetNextWaypoint();
        }
    }

    //Updates waypoints for the target waypoints
    private void targetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);    //Sets the previous waypoint to the current target
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);    //Will get the index of the next waypoint
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);  //Will update the index of the next waypoint

        _elapsedTime = 0;   //Resets the elapsed time to start moving towards teh new target

        //Will calculate the time required to reach the new target waypoing based on distance
        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);       //Makes the player a child when on the platform
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);        //Makes the player no longer a chile when on the platform
    }
}
