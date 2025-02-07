using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class score : MonoBehaviour
{public UnityEvent OnScoreChanged;
  public int Score{get; private set;}
  public void AddScore(int amount)
  {
    Score += amount;
    OnScoreChanged.Invoke();
  }
}
