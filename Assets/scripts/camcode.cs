using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class camcode : MonoBehaviour
{


    public Transform player; // Assign the player's transform in the Inspector
    public float smoothSpeed = 5f; // Adjust this for smoother turns

    private Vector3 offset; 

    void Start()
    {
        offset = transform.position - player.position; // Maintain initial offset
    }

    void LateUpdate()
    {
        // Keep camera position following the player
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        // Smoothly rotate the camera to match the player's forward direction
        Quaternion targetRotation = Quaternion.Euler(0, 0, player.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }
}

