using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class enemydestroy : MonoBehaviour
{
    
private Speedup driver;
void Start()
{
    driver=FindObjectOfType<Speedup>();
}

    
    public void DestroyEnemy()
    {   
       
        Destroy(gameObject, 1f);
       if(driver.canspeedup==false)
       { driver.count+=10;
       driver.OnSpeedChanged.Invoke();
       }
    }

}
