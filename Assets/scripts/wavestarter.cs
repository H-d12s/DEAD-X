using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class wavestarter : MonoBehaviour
{

    public TextMeshProUGUI waveText; // Reference to the TextMeshPro UI element
    public string waveMessage = "Wave Start"; // The message to display
    public float fadeDuration = 1f; // Duration of fade-in and fade-out
    public float displayTime = 3f; // How long the message should be fully visible
    public bool wavestart=false;
    public float timer=0;
    [SerializeField]private float waveduration;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("player"))
        {   wavestart=true;
            // Set the text and start the fade effect
            waveText.text = waveMessage;
            StartCoroutine(FadeText());
        }
    }

    void Update()
    {
        if(wavestart==true)
        {
            timer+=Time.deltaTime;
            if(timer>=waveduration)
            {
                wavestart=false;
                timer=0;
            }
        }
    }
    private IEnumerator FadeText()
    {
        // Fade in
        yield return StartCoroutine(Fade(0, 1, fadeDuration)); // Fade from transparent to opaque

        // Wait for the display time
        yield return new WaitForSeconds(displayTime);

        // Fade out
        yield return StartCoroutine(Fade(1, 0, fadeDuration)); // Fade from opaque to transparent

        // Disable the text after fading out
        waveText.gameObject.SetActive(false);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        // Get the current color of the text
        Color color = waveText.color;

        while (elapsedTime < duration)
        {
            // Calculate the new alpha value
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            waveText.color = color;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final alpha value is set
        color.a = endAlpha;
        waveText.color = color;
    }
}