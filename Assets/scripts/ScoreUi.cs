 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUi : MonoBehaviour
{
    private TMP_Text scoretext;
    private void Awake()
    {
        scoretext = GetComponent<TMP_Text>();
    }
    public void UpdateScore(score score)
    {
        scoretext.text= $"Score:{score.Score}";
    }
}
