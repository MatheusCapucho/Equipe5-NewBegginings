using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPosAgua = new Vector3(250f, -8.6f, 0); // posicao que o objeto vai instanciar,
    private Vector3 spawnPosBrasa = new Vector3(250f, 0f, 0); // nas coordenadas (x,y,0).
    private Vector3 spawnPosCadeira = new Vector3(250f, 0f, 0); // mudar de acordo com o desejado, para cada objeto
    private Vector3 spawnPosBandeirinha1 = new Vector3(250f, 0f, 0);
    private Vector3 spawnPosBandeirinha2 = new Vector3(250f, 0f, 0);  

    private float repeatRate = 2f; // tempo entre repeticao dos objetos
    private float nextSpawn = 0;
    private int whatToSpawn; 

    public GameObject agua, brasa, cadeira, bandeirinha, fogueira; // obstaculos a serem instanciados (prefabs). 


    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);


            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(agua, spawnPosAgua, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(brasa, spawnPosBrasa, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(cadeira, spawnPosCadeira, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(bandeirinha, spawnPosBandeirinha1, Quaternion.Euler(0f, 0f, 180f));
                    break;
                case 5:
                    Instantiate(fogueira, spawnPosBandeirinha2, Quaternion.identity);
                    break;
            }

            nextSpawn = Time.time + repeatRate;
        }

    }


}
