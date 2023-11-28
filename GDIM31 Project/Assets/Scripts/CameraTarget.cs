using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    PlayerController pc;
    [SerializeField]
    float offset;

    float playerPosition;

    void Update()
    {
        playerPosition = pc.transform.position.y;
        transform.position = new Vector3(0f, playerPosition + offset, 0f);
    }
}
