using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tnt : MonoBehaviour
{public GameObject explosion;
private healthcontroller healthcontroller;
void Start()
{
    healthcontroller=GameObject.FindGameObjectWithTag("player").GetComponent<healthcontroller>();
}
    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if(collsion.CompareTag("player"))
        {
            Instantiate(explosion,transform.position,transform.rotation);
            healthcontroller.takeDamage(100f);
            Destroy(gameObject);

        }
    }
}
