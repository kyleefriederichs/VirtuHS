using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollercoaster : MonoBehaviour // place this script on the cart object
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    int targetIndex = 0;
    float speed = 1.0f;
    private Transform targetPos;

    void Update()
    {
        if (targetIndex < waypoints.Count)
        {
            var step =  speed * Time.deltaTime; // calculate distance to move
            targetPos = waypoints[targetIndex];

            // physical movement
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);

            // rotation
            Vector3 targetDirection = targetPos.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Check if the position of the cube is within certain distance of a waypoint
            if (Vector3.Distance(transform.position, targetPos.position) < 0.001f)
            {
                // Update waypoint, if not end of the list
                if (targetIndex < waypoints.Count)
                {
                    targetIndex += 1;
                }
            }
        }
    }
}
