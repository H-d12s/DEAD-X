using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycollectibledrop : MonoBehaviour
{
   [SerializeField] private float chanceofcollectible;
   private collectibleSpawner collectibleSpawner;

   private void Awake()
   {
    collectibleSpawner=FindObjectOfType<collectibleSpawner>();

   }
   public void RandomlyDropCollectible()
   {
        float random = Random.Range(0f,1f);

        if(chanceofcollectible>=random)
        {
            collectibleSpawner.SpawnCollectible(transform.position);
        }
   }

    }

