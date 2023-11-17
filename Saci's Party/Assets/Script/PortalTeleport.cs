using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PortalTeleport : MonoBehaviour
{
    public GameObject teleportCanvas;
    public GameObject teleportCanvasYes;

    void Start()
    {
        teleportCanvas.SetActive(false);
        teleportCanvasYes.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger ativado!");
            teleportCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Yes()
    {
        teleportCanvas.SetActive(false);
        teleportCanvasYes.SetActive(true);
        Time.timeScale = 0;
    }

    public void LetsGo()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 0;
    }

    public void No()
    {
        teleportCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Nevermind()
    {
        teleportCanvasYes.SetActive(false);
        Time.timeScale = 1;
    }



}
