using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyred : MonoBehaviour
{
    private bool ishit;
    private SpriteRenderer sr;
    private Color originalColor;
    [SerializeField] private float colorChangeDuration = 0.5f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            ishit = true;
           couroutinestart();
        }
    }
    public void couroutinestart()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(colorChangeDuration);
        sr.color = originalColor;
    }
}
