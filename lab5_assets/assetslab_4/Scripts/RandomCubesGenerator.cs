using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int objectNumber = 5;
    public Material[] materials;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        Vector3 platformPosition = transform.position;
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach

        for (int i = 0; i < objectNumber; i++)
        {
            this.positions.Add(new Vector3(platformPosition.x + Random.Range(-5f,5f),2,platformPosition.y + Random.Range(-5,5f)));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            int materialIndex = Random.Range(0, materials.Length);
            Material randomMaterial = materials[materialIndex];
            GameObject newCube = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            newCube.GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
