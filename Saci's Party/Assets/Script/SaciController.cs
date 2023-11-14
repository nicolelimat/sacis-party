using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaciController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 6;
    public int currentHealth;
    public float timeInvincible = 2.0f;
    // public int health { get { return currentHealth; }}
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    bool isInvincible;
    float invincibleTimer;
    float horizontal; 
    float vertical;
    bool isDead;
    float deathAnimationDuration = 2.5f;

    Rigidbody2D rigidbody2d;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public static event Action OnPlayerDeath; // Por ser estático e público, pode ser referenciado em outros scripts



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        // Verifica se o jogador está pressionando para a esquerda ou direita
        if (Mathf.Approximately(move.x, 1.0f) || Mathf.Approximately(move.x, -1.0f))
        {
            lookDirection.Set(move.x, 0); // Mantém a direção horizontal
        }
        else if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y); // Define a direção com base no movimento
        }

        // Verifica se o jogador está pressionando apenas a tecla para cima (UP)
        if (!Mathf.Approximately(move.y, 0.0f))
        {
            // Mantém a direção horizontal (não muda o olhar)
            lookDirection.Set(lookDirection.x, 0);
        }

        lookDirection.Normalize();

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
            
        }

        // Mudando os sprites de corações
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;   
        }
        for (int i = 0; i < currentHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        if(isDead == false)
        {
            rigidbody2d.MovePosition(position);
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) // Se estiver invencível, sai da função sem tomar dano
                return;
            
            isInvincible = true; // Senão, se torna invencível por X sec e toma dano
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

        if(isDead == false && currentHealth == 0){
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("You're dead!");
        isDead = true;
        animator.SetTrigger("Death");
        // rigidbody2d.bodyType = RigidbodyType2D.Static;
    
        // Aguardar a duração da animação de morte antes de mostrar o painel de game over
        StartCoroutine(ShowGameOverAfterDeathAnimation());
    }

    IEnumerator ShowGameOverAfterDeathAnimation()
    {
        yield return new WaitForSeconds(deathAnimationDuration);
        OnPlayerDeath?.Invoke();
    }
}
