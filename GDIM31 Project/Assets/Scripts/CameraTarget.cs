using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    PlayerController pc;

    float playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = pc.transform.position.y;
        transform.position = new Vector3(0f, playerPosition, 0f);
    }
}
