using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{

    public SpriteRenderer playerMask;
    public int coins = 0;


    private void Update()
    {
        this.gameObject.GetComponent<Text>().text = "Coins: " + coins.ToString();
    }

}
