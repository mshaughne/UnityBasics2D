using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    // when something enters the coin trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the object has the Player tag
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ObtainCoin();
            // get the coin
            Debug.Log("You got a coin!");
            // destroy the coin
            Destroy(gameObject);
        }
    }
}
