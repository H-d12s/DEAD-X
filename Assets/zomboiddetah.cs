using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zomboiddetah : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="bullet")
        {
            Destroy(gameObject);
        }
        Destroy(other.gameObject);    }
}
