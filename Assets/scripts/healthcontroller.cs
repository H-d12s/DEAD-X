using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class healthcontroller : MonoBehaviour
{
   [SerializeField] private float currenthealth;
    [SerializeField]private float maxhealth;

    public float Remaininghealth
    {
        get
        {
            return currenthealth/maxhealth;
        }
    }
    public bool isinvincible;
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;
    public int dead=0;

    public void takeDamage(float damage)
    {
       if(currenthealth == 0)
       {
          return;
       }
       if(isinvincible)
       {
           return;
       }
       currenthealth -= damage;
       OnHealthChanged.Invoke();
         if(currenthealth < 0)
         {
              currenthealth = 0;
         }
    if (currenthealth==0)
    {dead=1;
        OnDied.Invoke();
        
    }
    else
    {
        OnDamaged.Invoke();
    }
}
public void Addhealth(float health)
{
    if(currenthealth == maxhealth)
    {
        return;
    }
    currenthealth += health;
    OnHealthChanged.Invoke();
    if(currenthealth > maxhealth)
    {
        currenthealth = maxhealth;
    }


}}
