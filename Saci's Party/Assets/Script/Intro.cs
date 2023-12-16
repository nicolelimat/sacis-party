using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour
{
    public CanvasGroup[] images; // Adicione os CanvasGroups das imagens no Unity Editor
    public CanvasGroup[] texts; // Adicione os CanvasGroups dos textos no Unity Editor
    public float displayTime = 3f; // Tempo de exibição de cada imagem/texto
    public float transitionTime = 0.5f; // Tempo de transição entre as imagens/textos
    public string nextSceneName; // Nome da cena da tela inicial

    IEnumerator Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            StartCoroutine(DisplayImageAndText(images[i], texts[i]));
            yield return new WaitForSeconds(displayTime + transitionTime);
        }

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextSceneName); // Carrega a tela inicial do jogo
    }

    IEnumerator DisplayImageAndText(CanvasGroup image, CanvasGroup text)
    {
        FadeIn(image);
        FadeIn(text);
        yield return new WaitForSeconds(displayTime);
        FadeOut(image);
        FadeOut(text);
    }

    void FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        StartCoroutine(Fade(canvasGroup, 1, transitionTime));
    }

    void FadeOut(CanvasGroup canvasGroup)
    {
        StartCoroutine(Fade(canvasGroup, 0, transitionTime));
    }

    IEnumerator Fade(CanvasGroup canvasGroup, float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, (Time.time - startTime) / duration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}
