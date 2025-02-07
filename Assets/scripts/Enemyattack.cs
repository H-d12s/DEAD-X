using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    [SerializeField]private float damage;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            var healthcontroller = other.gameObject.GetComponent<healthcontroller>();
           
            healthcontroller.takeDamage(damage);
        }
    }
}

