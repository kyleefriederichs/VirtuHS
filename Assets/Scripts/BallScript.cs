using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] Transform other_TP_point;
    [SerializeField] private Transform respawnPoint;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Respawn the ball if it falls below a certain Y position
        if (transform.position.y < -2.0f)
        {
            rb.isKinematic = true;
            transform.position = respawnPoint.position;
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tp"))
        {
            rb.isKinematic = true;
            transform.position = other_TP_point.position;
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("GOAL!");
            gameObject.SetActive(false);
        }
    }
}
