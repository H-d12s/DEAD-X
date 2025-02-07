using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
   
    void Update()
    {
        Instantiate( bomb, transform.position, Quaternion.identity);
    }
}
