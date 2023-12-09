using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject fartPrefab;

    [Header("SpawnBoundaries")]

    [SerializeField]
    float left;

    [SerializeField]
    float right;

    [SerializeField]
    float bottom;

    [SerializeField]
    float top;

    Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        randomPosition = new Vector3(Random.Range(left, right), Random.Range(bottom, top), 0);
        Instantiate(fartPrefab, randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
