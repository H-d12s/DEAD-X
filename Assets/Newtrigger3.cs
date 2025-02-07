using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newtrigger3 : MonoBehaviour
{
  public int alreadydelivered = 0;
  
   public  Driver logic;
   
   void Start()
   {
    logic = GameObject.FindGameObjectWithTag("player").GetComponent<Driver>();
    
   
   }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="player" && logic.haspackage==true) 
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("Delivered");
            
            logic.count++;
           
          
        }
        else if(other.gameObject.tag=="player" && logic.haspackage == false && GetComponent<SpriteRenderer>().color != Color.black)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
         
        }
    }}