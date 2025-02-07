using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
     private Camera maincam;

   private Vector3 mousePos;
   public GameObject bullet;
   public Transform bullettrasform;
   public bool canfire;
   public float timer;
   public float timebetweenfiring;


    void Start()
    {
       maincam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        mousePos=maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation= mousePos-transform.position;
        float rotZ = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0f,0f,rotZ-90);

        if(!canfire)
        {
            timer+=Time.deltaTime;
            if(timer>=timebetweenfiring)
            {
                canfire=true;
                timer=0;
            }
        }

        if(Input.GetMouseButton(0) && canfire)
        {
            Instantiate(bullet,bullettrasform.position,Quaternion.identity);
            canfire=false;
        }
    }
}

