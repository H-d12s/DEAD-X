using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floaty : MonoBehaviour
{

    public float floatHeight = 0.5f; // How high it floats
    public float floatSpeed = 2f; // Speed of floating

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Store the initial position
    }

    void Update()
    {
        // Move up and down using Sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}


