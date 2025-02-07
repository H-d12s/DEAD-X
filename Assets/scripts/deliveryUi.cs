using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deliveryUi : MonoBehaviour
{
       private TMP_Text delivery;
    private void Awake()
    {
        delivery = GetComponent<TMP_Text>();
    }
    public void UpdateScore(donedeliver donedelivery)
    {
        delivery.text= $"Delivery:{donedelivery.delivered}/3";
    }
  
}
