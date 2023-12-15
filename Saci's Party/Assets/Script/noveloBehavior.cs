using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noveloBehavior : MonoBehaviour
{

    public Vector3 direction;         //Transform do objeto que será seguido
    float speed = 10.0f;        //Velocidade que a bala anda
    float instanceTimer = 5.0f;
   

    Animator animator;

    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        //A direção que você quer seguir é a diferença entre a posição do jogador (alvo) - a posição atual da bala
        direction = FindObjectOfType<SaciController>().transform.position - transform.position;
        animator = GetComponent<Animator>();

        direction = direction.normalized;
        
        spriteRenderer = GetComponent<SpriteRenderer>();



        if(direction.x > 0){
            spriteRenderer.flipX = false;
        }else{
            spriteRenderer.flipX = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction  * speed  * Time.deltaTime);

        if(instanceTimer < 0){
            Destroy(gameObject);
        }else{
            instanceTimer -= Time.deltaTime;
        }

       
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SaciController player = other.GetComponent<SaciController >();

        if (player != null)
        {
            animator.SetBool("IsHit",true);
            player.ChangeHealth(-2);
            speed -= speed;
        }
        if(other.tag == "Wall"){
            animator.SetBool("IsHit",true);
            speed -= speed;
        }
    }

    void finalizar(){
        Destroy(gameObject);
    }

}
