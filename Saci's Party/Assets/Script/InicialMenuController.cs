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
            // Application.Quit();
        } 

        if (Input.anyKeyDown)
        {
          SceneManager.LoadScene("SampleScene");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
