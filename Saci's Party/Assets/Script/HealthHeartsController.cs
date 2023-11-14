using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthHeartsController : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Mudando os sprites de corações
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;   
        }
        for (int i = 0; i < SaciController.currentHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        } 
    }
}
