using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    AudioSource pickUpSound;

    protected PlayerStats player;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.GetComponent<PlayerStats>();
            PickedUp();
        }
    }

    protected virtual void PickedUp()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        pickUpSound.Play();
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
