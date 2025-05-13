using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatEnemy : MonoBehaviour
{
    public GameObject deathParticle;
    public AudioClip deathSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.parent.position, 1f);
            Instantiate(deathParticle, transform.parent.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerMove>().Bounce();
            Destroy(transform.parent.gameObject);
        }
    }
}
