using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused;

    void Start(){
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = pauseMenu.gameObject.activeSelf;
            if(isPaused){
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            } else {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
