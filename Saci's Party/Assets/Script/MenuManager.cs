using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public CanvasGroup gameOverCanvasGroup;
    bool isPaused;
    public static bool isOver;

    void Start()
    {
        isOver = false;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        gameOverCanvasGroup.alpha = 0; // Painel de game over totalmente transparente
    }

    void Update()
    {
        if (isOver == false && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = pauseMenu.gameObject.activeSelf;
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void OnEnable()
    {
        SaciController.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        SaciController.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        isOver = true;
        // Efeito de fade-in gradual
        StartCoroutine(FadeInGameOverPanel());
    }

    IEnumerator FadeInGameOverPanel()
    {
        float duration = 0.5f; // Duração do fade 
        float timer = 0;

        while (timer < duration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / duration);
            gameOverCanvasGroup.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Painel de game over totalmente visível no final
        gameOverCanvasGroup.alpha = 1;
    }
}
