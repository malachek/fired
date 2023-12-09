using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject fartPrefab;

    [Header("SpawnBoundaries")]
    [SerializeField] float left;
    [SerializeField] float right;
    [SerializeField] float bottom;
    [SerializeField] float top;

    void Start()
    {
        // Spawn burrito in random location within confined area
        Instantiate(fartPrefab, new Vector3(Random.Range(left, right), Random.Range(bottom, top), 0), Quaternion.identity);
    }
}
