using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoBehavior : MonoBehaviour
{
    public float speed = 0.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    public int health = 2;

    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    public GameObject Flecha;
    bool canAttack = true;

    float range = 7f;
    
    Animator animator;
    SpriteRenderer spriteRenderer;
    private Color originalColor;

    GameObject player = null;
    
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

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        if(canAttack && saciInRange()){
            canAttack = false;
            animator.SetBool("Atack",true);
            
        }
    }
    
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if(transform.position.x - player.transform.position.x < 0){
            spriteRenderer.flipX = false;
            //animator.SetFloat("Move X", 1);
        }else{
            spriteRenderer.flipX = true;
            //animator.SetFloat("Move X", -1);
        }
        
    }

    public void Disparo(){
        animator.SetBool("Atack",false);
        StartCoroutine(AttackCoroutine());
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

    IEnumerator AttackCoroutine()
    {
     
            
        GameObject novoProjetil = Instantiate(Flecha, transform.position ,Quaternion.identity);

        yield return new WaitForSeconds(4f); 

        canAttack = true; // Permite novos ataques após o intervalo
        
    }

    private bool saciInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance <= range){
            return true;
        }else{
            return false;
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

