using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newbullet : MonoBehaviour
{
    private Camera maincam;

   private Vector3 mousePos;
   private Rigidbody2D rb;
   public float force;
   public enemyhealth enemyhealth;
   public enemyspawner enemyspawner;
    void Start()
    {  
  
        
        
  
        maincam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb=GetComponent<Rigidbody2D>();
        mousePos=maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos-transform.position);
        Vector3 rotation=transform.position-mousePos;
        rb.velocity= new Vector2(direction.x,direction.y).normalized*force;
        float rot = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0f,0f,rot+90);
    }
    void Update()
    {
        DestroybulletOffScreen();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("zombie") || collision.CompareTag("boss"))
        {   healthcontroller healthcontroller = collision.GetComponent<healthcontroller>();
            healthcontroller.takeDamage(10);
          
            Destroy(gameObject);
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
