using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaBehavior : MonoBehaviour
{
    public float speed = 2.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    public int health = 2;

    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    GameObject player = null;
    SpriteRenderer spriteRenderer;
    private Color originalColor;

    bool findPlayer = false;

    float pursuitRange = 7f;
    
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(!findPlayer){

            Pursuit();

            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
            }
        }

    }
    
    void FixedUpdate()
    {
        if(!findPlayer){
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
        }else{
            if(player != null){
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                if(transform.position.x - player.transform.position.x < 0){
                    animator.SetFloat("Move X", 1);
                }else{
                    animator.SetFloat("Move X", -1);
                }
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        SaciController player = other.gameObject.GetComponent<SaciController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Hurt(int amount){
        health += amount;
        if(health == 0){
            Destroy(gameObject);
        }
        StartCoroutine(FlashRed());
    }

    private void Pursuit()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= pursuitRange){
            findPlayer = true;
        }else{
            findPlayer = false;
        }
    }

    private IEnumerator FlashRed()
    {
        // Muda temporariamente a cor do SpriteRenderer para vermelho
        spriteRenderer.color = Color.red;

        // Aguarda meio segundo
        yield return new WaitForSeconds(0.1f);

        // Restaura a cor original do SpriteRenderer
        spriteRenderer.color = originalColor;
    }
}

