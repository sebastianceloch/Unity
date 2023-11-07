using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float platformSpeed = 2.0f;
    public float destinationX = 10.0f;
    private Vector3 initialPosition;
    private int direction = 1;

    private bool playerOnPlatform = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            
            transform.Translate(Vector3.right * platformSpeed * direction * Time.deltaTime);

            
            if ((direction == 1 && transform.position.x >= destinationX) || (direction == -1 && transform.position.x <= initialPosition.x))
            {
                direction *= -1;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}