using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaximboBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SaciController player = other.GetComponent<SaciController >();

        if (player != null)
        {
            player.Boost();
            Destroy(gameObject);
        }

    }
}
