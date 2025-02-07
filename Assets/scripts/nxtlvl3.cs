using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nxtlvl3 : MonoBehaviour
{public Driver driver;
void Start()
{
    driver = GameObject.FindObjectOfType<Driver>();
}
    private void OnTriggerEnter2D(Collider2D collision)
 {
    if(collision.CompareTag("player") &&driver.count==3)
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
        
    }
 }
    }

