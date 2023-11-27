using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Destroy(gameObject);
            CoinCounter.instance.AddCoins(value);
        }
    }
}
