using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject>collectableprefabs;
    public void SpawnCollectible(Vector2 position)
    {
        int index = Random.Range(0,collectableprefabs.Count);
        var selectcollectible = collectableprefabs[index];
        Instantiate(selectcollectible,position,Quaternion.identity);
    }
    
}
