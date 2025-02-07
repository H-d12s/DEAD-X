using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="player")
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

private void OnTriggerExit2D(Collider2D other)
{
    if(other.gameObject.tag=="player")
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
}
