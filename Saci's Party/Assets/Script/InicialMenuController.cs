using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicialMenuController : MonoBehaviour
{
    public GameObject PlayButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } 

        if (Input.GetKeyDown(KeyCode.M))
        {
            return;
        } 

        if (Input.anyKeyDown)
        {
          StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
