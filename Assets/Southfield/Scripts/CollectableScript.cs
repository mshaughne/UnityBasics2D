using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public AudioClip coinSound;

    // when something enters the coin trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the object has the Player tag
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManagerSF.Instance.ObtainCoin();
            // get the coin
            Debug.Log("You got a coin!");
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            // destroy the coin
            Destroy(gameObject);
        }
    }
}
