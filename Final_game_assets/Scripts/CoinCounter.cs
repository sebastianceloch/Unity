using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;
    public int curCoins = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinText.text = "COINS: " + curCoins.ToString();
    }

    public void AddCoins(int value)
    {
        curCoins += value;
        coinText.text = "COINS: " + curCoins.ToString();
    }
}
