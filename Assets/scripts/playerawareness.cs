using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerawareness : MonoBehaviour
{
    public bool AwareOfPlayer{get;private set;}
    public Vector2 DirectionToPlayer{get;private set;}
    [SerializeField]private float playerawarenessdistance;
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemytoplayerpos =player.position - transform.position;
        DirectionToPlayer = enemytoplayerpos.normalized;
        if(enemytoplayerpos.magnitude <= playerawarenessdistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
