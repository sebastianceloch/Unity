using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float openDistance = 4.0f;
    public float slideSpeed = 4.0f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(openDistance, 0, 0);
    }

    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

        
        if (distanceToPlayer < openDistance)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, slideSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, slideSpeed * Time.deltaTime);
        }
    }
}