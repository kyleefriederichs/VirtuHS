using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private float changeInterval = 1.0f; // Time in seconds between color changes
    [SerializeField] private Renderer cubeRenderer;
    private float timer;

    void Start()
    {
        // cubeRenderer = GetComponent<Renderer>();
        timer = changeInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            change();
            timer = changeInterval; // Reset timer
        }
    }

    void change()
    {
        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
