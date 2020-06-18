using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    
    private float burnedModifier = 0.75f; // valor entre 0 e 1. Quanto mais perto de 0, menos ela pula.
    public bool grounded;
    public float tempoDeDebuff = 10f;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public bool gameOver = false;
    public bool finishGame = false;
    public int hearts = 2;
    public bool molhada = false;
    public bool queimada = false;
    public LayerMask mask;
    public GameObject deathObject;
    int aux = 1; //auxilia no pulo quando esta queimada
    bool aux2 = true;
    bool aux3 = true;
    public GameObject Player;
    private float horizontalBound = -56f;
    public GameObject CoinsUI;
    public GameObject textoFinal;
    public GameObject hippie;

    public int playerState = 0; //(skins) 0 normal, 2deagua, 3defogo, 4ostentacao, 1pazEAmor; 
   // public SpriteRenderer sr;
    void Start()
    {
       // sr = this.gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (CoinsUI.GetComponent<CoinHandler>().coins == 10)
        {
            StartCoroutine(GameFinished());
        }

        this.gameObject.GetComponent<Animator>().SetInteger("PlayerState", playerState);

        if (Player.transform.position.x < horizontalBound)
        {
            gameOver = true;
        }

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
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Abaixar");
        }

        if (rb.velocity.y < 0)
        {
            if (Input.GetKey(KeyCode.Space) && !molhada)
            {
                rb.gravityScale = 4f; // gravidade planando
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
            StartCoroutine(Die());
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
        this.gameObject.GetComponent<Animator>().SetTrigger("Abaixar");
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            rb.gravityScale = 5.4f; //gravidade no chao
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
            hearts--;
            StartCoroutine(Watered());
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

    IEnumerator Watered () //a galinha esta no estado molhada
    {
        if (playerState != 2) //nao esta com skin aquatica
        {
            molhada = true;
            this.gameObject.GetComponent<Animator>().SetInteger("PlayerState", 2);

            yield return new WaitForSeconds(tempoDeDebuff);

            this.gameObject.GetComponent<Animator>().SetInteger("PlayerState", playerState);
            molhada = false;
        }
    }
    IEnumerator Burned() // a galinha esta no estado queimada
    {
        if (playerState != 3) //nao esta com skin de fogo
        {
            queimada = true;
            this.gameObject.GetComponent<Animator>().SetInteger("PlayerState", 3);

            if (aux == 1)
            {
                Jump();
                aux = 0; // variavel auxiliar, para nao fazer a funcao varias vezes.
            }

            
            yield return new WaitForSeconds(tempoDeDebuff);
            aux = 1;

            
        }

        this.gameObject.GetComponent<Animator>().SetInteger("PlayerState", playerState);
        queimada = false;
    }
    IEnumerator Die()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        
        if (aux2)
        {        
            Instantiate(deathObject, Player.transform.position, Quaternion.identity);    
        }
        aux2 = false;

        yield return new WaitForSeconds(1.5f);

        gameOver = false;
        hearts = 2;
        SceneManager.LoadScene(0);
    }
    IEnumerator GameFinished()
    {
        textoFinal.SetActive(true);
        if (aux3)
        {
            Instantiate(hippie, Player.transform.position, Quaternion.identity);
        }
        aux3 = false;



        yield return new WaitForSeconds(3.6f);
        SceneManager.LoadScene(0);
    }

}
