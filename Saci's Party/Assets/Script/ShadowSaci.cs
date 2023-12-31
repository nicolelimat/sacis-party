using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSaci : MonoBehaviour
{
    public float speed = 2.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
        }
        
        rigidbody2D.MovePosition(position);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        SaciController player = other.gameObject.GetComponent<SaciController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}