using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBehavior : MonoBehaviour
{
   
    GameObject enemy ;       
    public float speed = 5.0f;             //Velocidade do movimento

    void Start() {

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"){
            if (other.gameObject.GetComponent<FantasmaBehavior>() != null){
                FantasmaBehavior target = other.GetComponent<FantasmaBehavior >();
                target.Hurt(-1);
                speed -= speed;
                Destroy(gameObject);
            }
            if(other.gameObject.GetComponent<EsqueletoBehavior>() != null){
                EsqueletoBehavior target = other.GetComponent<EsqueletoBehavior >();
                target.Hurt(-1);
                speed -= speed;
                Destroy(gameObject);
            }
            
            

        }
        
    }
}

    

   

