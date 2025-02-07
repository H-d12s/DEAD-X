using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibility : MonoBehaviour
{
private healthcontroller healthcontroller;
private void Awake()
{
    healthcontroller = GetComponent<healthcontroller>();
}
public void StartInvincibility( float duration)
{
    StartCoroutine(InvincibilityCoroutine(duration));
}
private IEnumerator InvincibilityCoroutine(float duration)
{
    healthcontroller.isinvincible = true;   
    yield return new WaitForSeconds(duration);
    healthcontroller.isinvincible = false;
}

    }

