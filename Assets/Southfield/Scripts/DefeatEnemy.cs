using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMove>().Bounce();
            Destroy(transform.parent.gameObject);
        }
    }
}
