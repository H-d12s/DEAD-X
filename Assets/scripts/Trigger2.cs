using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="player")
        {
            GetComponent<SpriteRenderer>().color = Color.green;
           
           
    }}

}
