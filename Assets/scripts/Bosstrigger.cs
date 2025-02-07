using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosstrigger : MonoBehaviour
{private healthcontroller health;
void Start()
{
    health= GameObject.FindGameObjectWithTag("player").GetComponent<healthcontroller>();
}
private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.CompareTag("player") )
    {
        health.takeDamage(10f);
    }
}
}
