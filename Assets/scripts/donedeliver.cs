using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class donedeliver : MonoBehaviour
{
    public UnityEvent OnDelivered;
  public int delivered{get; private set;}
  public void Addcount(int amount)
  {
    delivered += amount;
    OnDelivered.Invoke();
  }
}
