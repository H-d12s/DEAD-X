using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public float rotatespeed;
    public float speed;
    public GameObject explosioneffect;
    private healthcontroller targethealth;
    public float lifetime=5f;
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        targethealth= GameObject.FindGameObjectWithTag("player").GetComponent<healthcontroller>();
        
        StartCoroutine(Destroylifetime());

    }
    void FixedUpdate(){
        Vector2 direction = (Vector2) target.position-rb.position;
        direction.Normalize();
        float rotateamount = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity= -rotateamount* rotatespeed;
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D collsion)

    {   
       if(collsion.CompareTag("player"))
        {Instantiate(explosioneffect,transform.position,transform.rotation);
         targethealth.takeDamage(50f);
        Destroy(gameObject);}
    }
IEnumerator Destroylifetime()

{
    yield return new WaitForSeconds(5f);
    Instantiate(explosioneffect,transform.position,transform.rotation);
    Destroy(gameObject);

}}
