using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatingCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float radius = 5f;
    void Start()
    {
        for (int i = 0; i <= numberOfCubes; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfCubes;
            float x = Mathf.Cos(angle) * Random.Range(-10f,10f);
            float z = Mathf.Sin(angle) * Random.Range(-10f, 10f);
            Vector3 randomPosition = new Vector3(x, 0, z);
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }
}
