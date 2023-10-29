using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlinkingWithFade : MonoBehaviour
{
    public Text textToBlink;
    public float blinkInterval = 0.7f;
    public float fadeDuration = 0.6f;
    private bool isTextVisible = true;

    private void Start()
    {
        StartCoroutine(BlinkWithFade());
    }

    private IEnumerator BlinkWithFade()
    {
        while (true)
        {
            if (isTextVisible)
            {
                StartCoroutine(FadeOut());
            }
            else
            {
                StartCoroutine(FadeIn());
            }
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - (elapsedTime / fadeDuration);
            textToBlink.color = new Color(textToBlink.color.r, textToBlink.color.g, textToBlink.color.b, alpha);
            yield return null;
        }
        textToBlink.color = new Color(textToBlink.color.r, textToBlink.color.g, textToBlink.color.b, 0);
        isTextVisible = false;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = elapsedTime / fadeDuration;
            textToBlink.color = new Color(textToBlink.color.r, textToBlink.color.g, textToBlink.color.b, alpha);
            yield return null;
        }
        textToBlink.color = new Color(textToBlink.color.r, textToBlink.color.g, textToBlink.color.b, 1);
        isTextVisible = true;
    }
}
