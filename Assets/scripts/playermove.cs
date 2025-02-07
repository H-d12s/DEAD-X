using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class playermove : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGrounded = true;
    int jumpCount = 0;

    public int speed = 5;
    public float jumpForce = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement (optional)
       

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player touches the ground
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count
        }
    }
}