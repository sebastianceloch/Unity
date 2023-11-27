using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector2 startPos;
    public int deathCount = 1;
    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Spike"))
        {
            Resp();
            DeathCounter.instance.AddDeaths(deathCount);
        }
    }

    void Resp()
    {
        transform.position = startPos;
    }
}
