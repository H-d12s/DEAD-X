using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nitrokill : MonoBehaviour
{public Driver move;
    void Start()
{
move =GameObject.FindGameObjectWithTag("player").GetComponent<Driver>();
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("zombie") && move.movespeed==30f || collision.CompareTag("boss") && move.movespeed==30f)
        {
            healthcontroller healthcontroller=collision.GetComponent<healthcontroller>();
            healthcontroller.takeDamage(100f);
        }
    }
}
