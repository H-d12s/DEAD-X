using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarui : MonoBehaviour
{
   [SerializeField] private UnityEngine.UI.Image healthbarforeground;
   [SerializeField] private UnityEngine.UI.Image heart;
   [SerializeField] private float heartbeatDuration = 0.5f;
   [SerializeField] private float heartbeatScale = 1.2f;

   public void Updatehealthbar(healthcontroller healthcontroller)
   {
      healthbarforeground.fillAmount = healthcontroller.Remaininghealth;
      StartCoroutine(HeartbeatEffect());
   }

   private IEnumerator HeartbeatEffect()
   {
      Vector3 originalScale = heart.rectTransform.localScale;
      Vector3 targetScale = originalScale * heartbeatScale;

      float elapsedTime = 0f;

      // Increase size
      while (elapsedTime < heartbeatDuration / 2)
      {
         heart.rectTransform.localScale = Vector3.Lerp(originalScale, targetScale, (elapsedTime / (heartbeatDuration / 2)));
         elapsedTime += Time.deltaTime;
         yield return null;
      }

      elapsedTime = 0f;

      // Decrease size
      while (elapsedTime < heartbeatDuration / 2)
      {
         heart.rectTransform.localScale = Vector3.Lerp(targetScale, originalScale, (elapsedTime / (heartbeatDuration / 2)));
         elapsedTime += Time.deltaTime;
         yield return null;
      }

      heart.rectTransform.localScale = originalScale;
   }
}