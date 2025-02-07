using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   private Camera maincam;

   private Vector3 mousePos;
   private Rigidbody2D rb;
   public float force;
    public enemyhealth enemyhealth;
    void Awake()
    {
        enemyhealth=GameObject.FindGameObjectWithTag("zombie").GetComponent<enemyhealth>();
    }
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

    // Update is called once per frame
    void Update()
    {
        
        
} 
private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="zombie")
        {
           enemyhealth.Changehealth(25f);
        }
        Destroy(gameObject);    }


}


