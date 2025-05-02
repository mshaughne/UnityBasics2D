using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxScript : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMove>().TakeDamage(damage);
        }
    }
}
