using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public GameObject gameOverMenu;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PartyHall()
    {
        SceneManager.LoadScene("PartyHall");
        Time.timeScale = 1;
    }
    
}
