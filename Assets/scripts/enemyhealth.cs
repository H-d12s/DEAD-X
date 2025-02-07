using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public float health=100f;
    public void Changehealth(float damage)
    {
        health-=damage;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}

