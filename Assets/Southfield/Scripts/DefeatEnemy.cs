using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatEnemy : MonoBehaviour
{
    public GameObject deathParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(deathParticle, transform.parent.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerMove>().Bounce();
            Destroy(transform.parent.gameObject);
        }
    }
}
