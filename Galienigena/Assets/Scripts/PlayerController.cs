using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public int playerState = 0; //(skins) 0 normal, 1 de agua, 2 de fogo, 3 ostentacao; 
    private float burnedModifier = 0.75f; // valor entre 0 e 1 (mudar)
    public bool grounded;
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public bool gameOver = false;
    public int hearts = 2;
    public bool molhada = false;
    private bool queimada = false;
    private bool invulneravel = false;
    public LayerMask mask;
    int aux = 1;


    void Start()
    {
       //sprite da skin atual
       //mudar o player state, de acordo com a skin (Fazer isso no menu).
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (molhada == true)
        {
            StartCoroutine(Watered()); 
        }
        if (queimada == true)
        {
            StartCoroutine(Burned());
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) 
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            Duck();
        }

        if (rb.velocity.y < 0)
        {
            if (Input.GetKey(KeyCode.Space) && !molhada)
            {
                rb.gravityScale = 2f; // gravidade planando
            } else
            {
                rb.gravityScale = 10f; //gravidade descendo
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y < 0)
        {
            rb.gravityScale = 10f; //gravidade descendo
        }
        
        if (gameOver)
        {
            GameOver();
        }
    }

    void Jump () // pulo
    {
        grounded = false;
        if (queimada == false)
        {
            rb.velocity += Vector2.up * jumpForce;
        } else
        {
            rb.velocity += Vector2.up * jumpForce * burnedModifier;
        }
       
    }

    void Duck () // abaixar
    {
        // animaçao dela abaixada, 
        // diminuir o collider
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            rb.gravityScale = 5f;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            grounded = false;
            hearts--;
            if (hearts == 0)
            {
                gameOver = true;
            }
        }
        if (other.gameObject.CompareTag("Agua"))
        {
            molhada = true;
        }
        if (other.gameObject.CompareTag("Brasa"))
        {
            hearts--;
            if (hearts == 0)
            {
                gameOver = true;
            }
            StartCoroutine(Burned());
            
        }
    }

    void GameOver () // fim de jogo
    {
        // some a sprite atual
        // animaçao de morte
        // tela de fim de jogo
        // menu e loja  
       
    }

    IEnumerator Watered () //a galinha esta no estado molhada
    {
        molhada = true;
        //Sprite da Galinha molhada

        yield return new WaitForSeconds(3f);

        //Sprite da skin atual
        molhada = false;
    }
    IEnumerator Burned() // a galinha esta no estado queimada
    {
        queimada = true;
        //Sprite da Galinha queimada

        if (aux == 1)
        {
            Jump();
            aux = 0; // variavel auxiliar, para nao fazer a funcao varias vezes.
        }

        yield return new WaitForSeconds(3f);

        aux = 1;

        //Sprite da skin atual
        queimada = false;
    }

    //daqui pra baixo, o codigo sera apenas sobre os poderes especiais, referentes às skins.


}
