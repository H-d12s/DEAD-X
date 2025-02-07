using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilescript : MonoBehaviour
{ public float speed = 5f;
    public float lifetime = 5f; // Destroy missile after X seconds
    private Vector2 moveDirection; // Stores the direction at launch
    private healthcontroller healthcontroller;

    public void SetDirection(Vector2 targetPosition)
    {
        moveDirection = (targetPosition - (Vector2)transform.position).normalized;

        // Rotate missile to face the initial target direction
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    private void Start()
    {   healthcontroller=GameObject.FindGameObjectWithTag("player").GetComponent<healthcontroller>();
        Destroy(gameObject, lifetime); // Destroy missile after some time
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("player"))
        {   healthcontroller.takeDamage(50f);
            Destroy(gameObject);

        }
    }
}

