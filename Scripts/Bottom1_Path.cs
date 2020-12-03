using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottom1_Path : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed = 1f;
    int waypointIndex = 0;
    float rotationZ;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        if (Timer_Manager.bottom1Activated == true)
        {
            if (waypointIndex <= waypoints.Count - 1)
            {
                var targetPosition = waypoints[waypointIndex].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
                if (transform.position == targetPosition)
                {
                    waypointIndex++;
                }
            }
        }
    }

}
