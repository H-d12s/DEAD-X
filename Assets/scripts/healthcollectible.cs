using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectible : MonoBehaviour , icollectibles
{[SerializeField]private float healthamount;
   public void OnCollected(GameObject player)
   {
    player.GetComponent<healthcontroller>().Addhealth(healthamount);
   }
}
