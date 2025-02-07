using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public bool haspackage;
    public float steerspeed = 250f;
    public float movespeed = 10f;  // Normal speed

    public float dashSpeed = 25f;  // Speed during dash
    public float dashDuration = 0.2f; // How long the dash lasts
    public float dashCooldown = 2f; // Time before player can dash again
    private bool canDash = true;
    public GameObject nitroeffect;
    public Transform nitro;
    public int count=0;
    public GameObject wavecol;
    private void Update()
    {
        // Move forward constantly
        float moveamount = Input.GetAxis("Vertical")*movespeed * Time.deltaTime;

        // Steer using horizontal input
        float steermount = Input.GetAxis("Horizontal") * steerspeed * Time.deltaTime;

        // Apply movement and rotation
        transform.Rotate(0, 0, -steermount);
        transform.Translate(0, moveamount, 0, Space.Self);

        // Dash mechanic (when Left Shift is pressed)
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        collideroff();
    }


    private IEnumerator Dash()
    {
        canDash = false;
        float originalSpeed = movespeed;
        Instantiate(nitroeffect,nitro.position,transform.rotation);
        movespeed = dashSpeed; // Increase speed

        yield return new WaitForSeconds(dashDuration); // Wait for dash time

        movespeed = originalSpeed; // Reset speed
        yield return new WaitForSeconds(dashCooldown); // Wait for cooldown
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "speedup")
        {
            movespeed = 16f;
            Debug.Log("Speed up");
        }
        if (other.gameObject.tag == "delivery" && !haspackage)
        {
            Debug.Log("Delivery picked up");
           
            haspackage = true;
            Destroy(other.gameObject);
        }
     
        
       
        else if (other.gameObject.tag == "delivered" && !haspackage)
        {
            Debug.Log("No delivery to deliver");
        }
    }
    private void collideroff()
    {
        if(count==2)
        {
            wavecol.SetActive(false);
        }
    }
}