using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdestroy : MonoBehaviour
{
   public GameObject explosive; // Start is called before the first frame update
    public void Destroy()
    {
        Instantiate(explosive,transform.position,transform.rotation);
        Destroy(gameObject,0.2f);
    }
}
