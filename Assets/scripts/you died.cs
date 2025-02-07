using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class YouDiedEffect : MonoBehaviour
{
    public TMP_Text youDiedText; // Assign in Inspector
    public Image backgroundImage; // Assign in Inspector
    public float fadeSpeed = 1f;
    private healthcontroller healthcontroller;

    void Start()
    {healthcontroller= FindObjectOfType<healthcontroller>();
        // Start fully transparent
        SetAlpha(youDiedText, 0);
        SetAlpha(backgroundImage, 0);

       
    }
        public void startcou()
    {
         
       {  
        // Start fade effect
        StartCoroutine(FadeInAndOut());}
    }

    IEnumerator FadeInAndOut()
    {
        // Fade in
        yield return StartCoroutine(FadeElements( 0, 1));
        

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

       yield return StartCoroutine(FadeElements(1, 0));
    }
 IEnumerator FadeElements(float startAlpha, float targetAlpha)
    {
        Color textColor = youDiedText.color;
        Color bgColor = backgroundImage.color;
        float elapsedTime = 0;

        while (elapsedTime < fadeSpeed)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeSpeed);

            textColor.a = alpha;
            bgColor.a = alpha * 0.9f; // Make background slightly less intense than text

            youDiedText.color = textColor;
            backgroundImage.color = bgColor;

            yield return null;
        }

        // Ensure final alpha is set exactly
        textColor.a = targetAlpha;
        bgColor.a = targetAlpha * 0.9f;
        youDiedText.color = textColor;
        backgroundImage.color = bgColor;
    }

    void SetAlpha(Graphic element, float alpha)
    {
        Color color = element.color;
        color.a = alpha;
        element.color = color;
    }
}