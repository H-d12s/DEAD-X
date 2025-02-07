using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscoreallocate : MonoBehaviour
{
 [SerializeField] private int Killscore;
 private score score;
 private void Awake()
 
 {
    score=FindObjectOfType<score>();
 }

 public void AllocateScore()
 {
    score.AddScore(Killscore);
 }
 }
