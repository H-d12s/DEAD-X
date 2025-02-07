using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevl : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D collision)
 {
    if(collision.CompareTag("player"))
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
        
    }
 }
}
