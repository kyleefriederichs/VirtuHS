using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalScript : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] GameObject ball;
    private Vector3 ballStartPos;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        updateScore();
        ballStartPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < -1f)
        {
            ResetBall();
        }
    }

    void updateScore()
    {
        scoreText.text = "Score = " + score;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++; // score = score + 1
            updateScore();
            ResetBall();
        }
        
    }

    void ResetBall()
    {
        ball.transform.SetPositionAndRotation(ballStartPos, Quaternion.identity);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            // the following the exact same as the previous 2 lines
        // Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        // ballRB.velocity = Vector3.zero;
        // ballRB.angularVelocity = Vector3.zero;
    }
}
