using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefeated : MonoBehaviour
{
    /// <summary>
    /// the gameobject that holds the particle we will be spawning
    /// </summary>
    public GameObject deathParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Bounce();

            // spawn the particle at the parent position in the identity rotation
            Instantiate(deathParticle, transform.parent.position, Quaternion.identity);

            Destroy(transform.parent.gameObject);
        }
    }
}
