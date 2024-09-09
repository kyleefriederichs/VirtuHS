using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform cp1;
    [SerializeField] private Transform cp2;
    private float speed = 0.4f;

    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = cp1.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object towards the target checkpoint
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Check if the object has reached the target
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            if (targetPos == cp1.position)
            {
                targetPos = cp2.position;
            }
            else
            {
                targetPos = cp1.position;
            }
        }
    }
}
