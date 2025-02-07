using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
 
    public float speed = 10f;
    private Vector2 moveDirection;
    private Camera maincam;

    public void SetDirection(Vector2 targetPosition)
    {    // Calculate direction only once when fired
        moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        transform.right = moveDirection; // Rotate the bullet to face the direction
    }
    void Start()
    {
         maincam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
        DestroybulletOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) // Damage player
        {
            collision.GetComponent<healthcontroller>().takeDamage(20f);
            Destroy(gameObject); // Destroy bullet
        }
       
    }

      private void DestroybulletOffScreen()
    {
       Vector2 screenpos = Camera.main.WorldToScreenPoint(transform.position);
       if(screenpos.x<0||screenpos.x>maincam.pixelWidth||screenpos.y<0||screenpos.y>maincam.pixelHeight)
       {
           Destroy(gameObject);
       }
        
    }
}


