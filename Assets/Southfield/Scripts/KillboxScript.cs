using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMove>().TakeDamage(9999);
        }
    }
}
