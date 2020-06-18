using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinValue = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Text").GetComponent<CoinHandler>().coins += coinValue;
            Destroy(this.gameObject);
        }
    }
}
