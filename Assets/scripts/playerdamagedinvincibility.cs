using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamagedinvincibility : MonoBehaviour
{[SerializeField] private float invincibilityTime;
    private invincibility invincibility;
    private void Awake()
    {
        invincibility = GetComponent<invincibility>();
    }
    public void StartInvincibility()
    {
       invincibility.StartInvincibility(invincibilityTime);
    }
}
