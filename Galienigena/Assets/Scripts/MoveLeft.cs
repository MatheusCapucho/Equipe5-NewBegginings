using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f; // velocidade com que as coisas vao pra esquerda
    private float lowerBound = -500; // lugar onde os objetos instanciados sao destruidos
    private PlayerController playerControllerScript;

    
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {

        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }



        if (transform.position.x < lowerBound)
        {
            Destroy(this.gameObject);
        }

    }
}
