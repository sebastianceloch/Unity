using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSquareMovement : MonoBehaviour
{
    public float speed = 3f;
    Vector3 curPos;
    void Start()
    {
        curPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Vector3.Distance(curPos, transform.position) >= 10.0f)
        {
            transform.Rotate(Vector3.up, 90.0f);
            curPos = transform.position;
        }
    }
}