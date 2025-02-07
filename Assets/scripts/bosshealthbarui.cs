using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosshealthbarui : MonoBehaviour
{
  [SerializeField] private UnityEngine.UI.Image healthbarforeground;
  

   public void Updatehealthbar(healthcontroller healthcontroller)
   {
      healthbarforeground.fillAmount = healthcontroller.Remaininghealth;
      
   }


}
