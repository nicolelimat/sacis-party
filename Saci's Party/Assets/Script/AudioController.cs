using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.loop = true;
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            audioSource.mute = !audioSource.mute;    
        } 
    }
}
