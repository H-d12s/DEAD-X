using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class speedupnew : MonoBehaviour
{
    public float count=0f;
    public float maxcount=100f;
    public altdriver move;
   public bool canspeedup=false;
   public UnityEvent OnSpeedChanged;
   public GameObject nitro1;
   public Transform nitrotransform;
public bool nitro=false;
 public float Remainingspeed
    {
        get
        {
            return count/maxcount;
        }
    }
   void Start()
   {
        move = GetComponent<altdriver>();
   }

   

    void Update()
    {
        if(count>=100f)
        {
            count=100f;
            canspeedup=true;
        }
        if(canspeedup)
        {
            if(Input.GetKey(KeyCode.Space))
            {   GameObject nitroEffect = Instantiate(nitro1, nitrotransform.position, transform.rotation);
    Destroy(nitroEffect, 0.3f);
                move.movespeed=30f;
                nitro=true;
                count-=15f*Time.deltaTime;
                OnSpeedChanged.Invoke();
            }
            if(move.movespeed==30f)
            {
                count-=15f*Time.deltaTime;
            }

            if(count<=0f)
            {
                count=0f;
                OnSpeedChanged.Invoke();
                canspeedup=false;
                nitro=false;

            }
        
        }
        else if(canspeedup==false)
        {
            move.movespeed=12f;
        }
    }

   
}


