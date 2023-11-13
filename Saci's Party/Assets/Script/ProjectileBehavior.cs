using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public Vector3 direction;         //Transform do objeto que será seguido
    float speed = 6.5f;        //Velocidade que a bala anda
    float instanceTimer = 5.0f;
   

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //A direção que você quer seguir é a diferença entre a posição do jogador (alvo) - a posição atual da bala
        direction = FindObjectOfType<SaciController>().transform.position - transform.position;
        animator = GetComponent<Animator>();

        direction = direction.normalized;
        



        if(direction.x > 0){
            animator.SetFloat("Look X", 1);
        }else{
            if(direction.x < 0){
                animator.SetFloat("Look X",-1);
            }
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
            player.ChangeHealth(-1);
            speed -= speed;
        }
    }

    void finalizar(){
        Destroy(gameObject);
    }

   
}
