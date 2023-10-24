using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfLerp : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 0.5f;

    private void Update()
    {
        Vector3 targetPosition = target.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
