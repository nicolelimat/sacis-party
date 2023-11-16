using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBehavior : MonoBehaviour
{
   
    GameObject enemy = null;       
    public float speed = 5.0f;             //Velocidade do movimento
    float instanceTimer = 4.0f;

    void Start() {


        GameObject[] nearbyEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Se há inimigos próximos, encontre o mais próximo.
        if (nearbyEnemies.Length > 0)
        {
            float shorterDistance = float.MaxValue;
            foreach (GameObject target in nearbyEnemies)
            {
                float actualDistance = Vector2.Distance(transform.position, target.transform.position);
                if (actualDistance < shorterDistance)
                {
                    shorterDistance = actualDistance;
                    enemy = target;
                }
            }
        }
        
    }

    void Update() {
        if(enemy != null){
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }

        if(instanceTimer < 0){
            Destroy(gameObject);
        }else{
            instanceTimer -= Time.deltaTime;
        }


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
            if(other.gameObject.GetComponent<MorcegoBehavior>() != null){
                MorcegoBehavior target = other.GetComponent<MorcegoBehavior >();
                target.Hurt(-1);
                speed -= speed;
                Destroy(gameObject);
            }
            
        }
        
    }
}

    

   

