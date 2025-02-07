using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private icollectibles collectable;

    private void Awake()
    {
        collectable=GetComponent<icollectibles>();
    }
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.gameObject.tag=="player")
        {   collectable.OnCollected(collision.gameObject);
            Destroy(gameObject);
        }
   }
}
